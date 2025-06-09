using AutoMapper;
using DeliveryAPI.Commands.OrderStatus;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using DeliveryAPI.Data.Primitives;
using MediatR;

namespace DeliveryAPI.Handlers.Orders.OrderStatus
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompleteOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(CompleteOrderCommand request, CancellationToken completelationToken)
        {
            OrderEntity? orderEntity = await _dbContext.Orders.FindAsync(request.Id);

            if (orderEntity == null)
                return NotFoundOperationResult.OrderNotFoundResult;

            if (orderEntity.Status != OrderStatusEnum.Assigned)
                return OrderIsNotAsignedResult;


            orderEntity.Status = OrderStatusEnum.Completed;
            orderEntity.ClosedAt = DateTime.UtcNow;
            orderEntity.CourierId = null;

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private readonly static SuccessOperationResult SuccessResult =
            new SuccessOperationResult()
            {
                Message = "Заявка успешно завершена!"
            };

        private readonly static InvalidRequestOperationResult OrderIsNotAsignedResult =
            new InvalidRequestOperationResult()
            {
                Message = "Заявка не была назначена курьеру в работу!"
            };
    }
}
