using AutoMapper;
using DeliveryAPI.Commands.Couriers;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Handlers.Couriers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteCourierCommand, IOperationResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOperationResult> Handle(DeleteCourierCommand request, CancellationToken cancellationToken)
        {
            CourierEntity? courierEntity = await _dbContext.Couriers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (courierEntity == null)
                return NotFoundOperationResult.CourierNotFoundResult;

            if (courierEntity.Orders.Any())
                return CourierHasOrdersResult;

            _dbContext.Remove(courierEntity);

            await _dbContext.SaveChangesAsync();

            return SuccessResult;
        }


        // Prepared operation results

        private static SuccessOperationResult SuccessResult { get; } =
            new SuccessOperationResult()
            {
                Message = "Курьер успешно удален из системы!"
            };

        private static InvalidRequestOperationResult CourierHasOrdersResult { get; } =
            new InvalidRequestOperationResult()
            {
                Message = "У курьера есть активные доставки!"
            };
    }
}
