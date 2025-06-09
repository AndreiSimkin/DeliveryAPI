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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            OrderEntity? orderEntity = await _dbContext.Orders.FindAsync(request.Id);

            if (orderEntity == null)
                return NotFoundOperationResult.OrderNotFoundResult;

            if (orderEntity.Status != OrderStatusEnum.New)
                return OnlyNewOrdersCanBeChangedResult;

            _mapper.Map(request, orderEntity);

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private static SuccessOperationResult SuccessResult { get; } =
            new SuccessOperationResult()
            {
                Message = "Заявка успешно обновлена!"
            };


        private static InvalidRequestOperationResult OnlyNewOrdersCanBeChangedResult { get; } =
            new InvalidRequestOperationResult()
            {
                Message = "Изменять можно только новые заявки!"
            };
    }
}
