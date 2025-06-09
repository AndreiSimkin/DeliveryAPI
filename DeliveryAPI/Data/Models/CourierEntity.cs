using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.Data.Models
{
    public class CourierEntity : BaseEntity<Guid>
    {
        /// <summary>
        /// ФИО курьера.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string FullName { get; set; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string PhoneNumber { get; set; }


        /// <summary>
        /// Назначенные заказы курьера.
        /// </summary>
        public required List<OrderEntity> Orders { get; set; }
    }
}
