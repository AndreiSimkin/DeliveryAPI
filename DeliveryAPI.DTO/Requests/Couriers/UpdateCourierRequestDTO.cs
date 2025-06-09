using DeliveryAPI.DTO.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Requests.Couriers
{
    public record UpdateCourierRequestDTO
    {
        /// <summary>
        /// Индификатор курьера.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// ФИО курьера.
        /// </summary>
        [FullName]
        public string? FullName { get; set; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        [Phone]
        [Length(11, 11)]
        public string? PhoneNumber { get; set; }
    }
}
