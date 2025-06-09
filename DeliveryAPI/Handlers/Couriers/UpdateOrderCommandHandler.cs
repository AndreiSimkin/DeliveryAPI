using AutoMapper;
using DeliveryAPI.Commands.Couriers;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using MediatR;

namespace DeliveryAPI.Handlers.Couriers
{
    public class UpdateCourierCommandHandler : IRequestHandler<UpdateCourierCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCourierCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(UpdateCourierCommand request, CancellationToken cancellationToken)
        {
            CourierEntity? courierEntity = await _dbContext.Couriers.FindAsync(request.Id);

            if (courierEntity == null)
                return NotFoundOperationResult.CourierNotFoundResult;

            _mapper.Map(request, courierEntity);

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private static SuccessOperationResult SuccessResult { get; } =
            new SuccessOperationResult()
            {
                Message = "Курьер успешно отредактирован!"
            };
    }
}
