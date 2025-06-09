using DeliveryAPI.Common.Interfaces;
using MediatR;

namespace DeliveryAPI.Commands.OrderStatus
{
    public record CompleteOrderCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }
    }
}
