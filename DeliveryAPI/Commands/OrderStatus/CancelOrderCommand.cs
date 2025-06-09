using DeliveryAPI.Common.Interfaces;
using MediatR;

namespace DeliveryAPI.Commands.OrderStatus
{
    public record CancelOrderCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Причина отменты заявки.
        /// </summary>
        public string? CancellationReason { get; init; }
    }
}
