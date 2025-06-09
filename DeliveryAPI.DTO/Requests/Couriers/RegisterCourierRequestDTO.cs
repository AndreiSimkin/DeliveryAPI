using DeliveryAPI.DTO.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Requests.Couriers
{
    public record class RegisterCourierRequestDTO
    {
        /// <summary>
        /// ФИО курьера.
        /// </summary>
        [MaxLength(100)]
        [FullName]
        public required string FullName { get; set; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        [Phone]
        [Length(11, 11)]
        public required string PhoneNumber { get; set; }
    }
}
