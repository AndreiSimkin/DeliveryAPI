using AutoMapper;
using DeliveryAPI.Commands.Couriers;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using MediatR;

namespace DeliveryAPI.Handlers.Couriers
{
    public class RegisterCourierCommandHandler : IRequestHandler<RegisterCourierCommand, CreateEntityOperationResult<Guid>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public RegisterCourierCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateEntityOperationResult<Guid>> Handle(RegisterCourierCommand request, CancellationToken cancellationToken)
        {
            CourierEntity courierEntity = _mapper.Map<CourierEntity>(request);

            await _dbContext.Couriers.AddAsync(courierEntity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            CreateEntityOperationResult<Guid> createEntityOperationResult =
                new CreateEntityOperationResult<Guid>()
                {
                    Id = courierEntity.Id,
                    Message = "Курьер успешно зарегистрирован!"
                };

            return createEntityOperationResult;
        }
    }
}
