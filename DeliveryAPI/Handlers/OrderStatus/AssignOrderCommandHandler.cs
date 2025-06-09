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
    public class AssignOrderCommandHandler : IRequestHandler<AssignOrderCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AssignOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(AssignOrderCommand request, CancellationToken cancellationToken)
        {
            OrderEntity? orderEntity = await _dbContext.Orders.FindAsync(request.Id);

            CourierEntity? courierEntity = await _dbContext.Couriers.FindAsync(request.CourierId);

            if (orderEntity == null)
                return NotFoundOperationResult.OrderNotFoundResult;

            if (courierEntity == null)
                return NotFoundOperationResult.CourierNotFoundResult;

            if (orderEntity.Status is not (OrderStatusEnum.New or OrderStatusEnum.Assigned))
                return OrderHasToBeNewOrAssignedResult;

            orderEntity.Status = OrderStatusEnum.Assigned;
            orderEntity.Courier = courierEntity;

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private readonly static SuccessOperationResult SuccessResult =
            new SuccessOperationResult()
            {
                Message = "Курьер успешно назначен на заявку!"
            };

        private readonly static InvalidRequestOperationResult OrderHasToBeNewOrAssignedResult =
            new InvalidRequestOperationResult()
            {
                Message = "Заявка должна быть новой или назначенной!"
            };
    }
}
