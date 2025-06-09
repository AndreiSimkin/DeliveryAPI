using DeliveryAPI.Common.Interfaces;
using MediatR;

namespace DeliveryAPI.Commands.OrderStatus
{
    public record AssignOrderCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Индификатор курьера.
        /// </summary>
        public required Guid CourierId { get; set; }
    }
}
