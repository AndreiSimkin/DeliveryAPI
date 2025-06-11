using AutoMapper;
using DeliveryAPI.Commands.OrderStatus;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using DeliveryAPI.Data.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Handlers.Orders.OrderStatus
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CancelOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            OrderEntity? orderEntity = await _dbContext.Orders
                .Include(d => d.OrderDetails)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (orderEntity == null)
                return NotFoundOperationResult.OrderNotFoundResult;

            if (orderEntity.Status == OrderStatusEnum.Cancelled)
                return OrderIsAlreadyCanceledResult;

            if (orderEntity.Status == OrderStatusEnum.Completed)
                return OrderIsAlreadyCompletedResult;

            if (string.IsNullOrWhiteSpace(request.CancellationReason) == false)
            {
                orderEntity.OrderDetails ??= new OrderDetailsEntity();
                orderEntity.OrderDetails.CancellationReason = request.CancellationReason;
            }

            orderEntity.Status = OrderStatusEnum.Cancelled;
            orderEntity.ClosedAt = DateTime.UtcNow;
            orderEntity.CourierId = null;

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private readonly static SuccessOperationResult SuccessResult =
            new SuccessOperationResult()
            {
                Message = "Заявка успешно отменена!"
            };

        private readonly static InvalidRequestOperationResult OrderIsAlreadyCanceledResult =
            new InvalidRequestOperationResult()
            {
                Message = "Заявка уже отменена!"
            };

        private readonly static InvalidRequestOperationResult OrderIsAlreadyCompletedResult =
            new InvalidRequestOperationResult()
            {
                Message = "Заявка уже закрыта!"
            };
    }
}
