using DeliveryAPI.DTO.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Common
{
    public record CourierDTO
    {
        /// <summary>
        /// Индификатор курьер.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// ФИО курьера.
        /// </summary>
        [FullName]
        public required string FullName { get; init; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        [Phone]
        [Length(11, 11)]
        public required string PhoneNumber { get; init; }


        /// <summary>
        /// Назначенные заказы курьера.
        /// </summary>
        public required List<OrderShortDTO> Orders { get; init; }
    }
}
