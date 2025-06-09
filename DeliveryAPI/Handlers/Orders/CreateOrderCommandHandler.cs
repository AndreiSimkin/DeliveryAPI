using AutoMapper;
using DeliveryAPI.Commands.Orders;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using MediatR;

namespace DeliveryAPI.Handlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateEntityOperationResult<Guid>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateEntityOperationResult<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            OrderEntity orderEntity = _mapper.Map<OrderEntity>(request);

            await _dbContext.Orders.AddAsync(orderEntity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            CreateEntityOperationResult<Guid> createEntityOperationResult =
                new CreateEntityOperationResult<Guid>()
                {
                    Id = orderEntity.Id,
                    Message = "Заявка успешно создана!"
                };

            return createEntityOperationResult;
        }
    }
}
