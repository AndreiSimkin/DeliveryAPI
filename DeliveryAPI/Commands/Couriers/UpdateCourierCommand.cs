using DeliveryAPI.Common.Interfaces;
using MediatR;

namespace DeliveryAPI.Commands.Couriers
{
    public record UpdateCourierCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор курьера.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// ФИО курьера.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
