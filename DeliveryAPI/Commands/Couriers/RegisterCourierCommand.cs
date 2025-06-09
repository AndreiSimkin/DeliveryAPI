using DeliveryAPI.Common.Models;
using MediatR;

namespace DeliveryAPI.Commands.Couriers
{
    public record RegisterCourierCommand : IRequest<CreateEntityOperationResult<Guid>>
    {
        /// <summary>
        /// ФИО курьера.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        public required string PhoneNumber { get; set; }
    }
}
