using AutoMapper;
using DeliveryAPI.Commands.Orders;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using DeliveryAPI.Data.Primitives;
using MediatR;

namespace DeliveryAPI.Handlers.Orders
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            OrderEntity? orderEntity = await _dbContext.Orders.FindAsync(request.Id);

            if (orderEntity == null)
                return NotFoundOperationResult.OrderNotFoundResult;

            if (orderEntity.Status == OrderStatusEnum.Assigned)
                return AssignedOrderCannotBeDeletedResult;

            _dbContext.Remove(orderEntity);

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private static SuccessOperationResult SuccessResult { get; } =
            new SuccessOperationResult()
            {
                Message = "Заявка успешно удалена!"
            };


        private static InvalidRequestOperationResult AssignedOrderCannotBeDeletedResult { get; } =
            new InvalidRequestOperationResult()
            {
                Message = "Этот заказ в работе у курьера, его нельзя удалять!"
            };
    }
}
