using DeliveryAPI.Common.Interfaces;
using MediatR;

namespace DeliveryAPI.Commands.Orders
{
    public record DeleteOrderCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }
    }
}
