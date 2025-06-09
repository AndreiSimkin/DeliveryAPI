using DeliveryAPI.Common.Interfaces;
using MediatR;

namespace DeliveryAPI.Commands.Couriers
{
    public record DeleteCourierCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор курьера.
        /// </summary>
        public required Guid Id { get; set; }
    }
}
