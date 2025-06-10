using System.ComponentModel.DataAnnotations;

namespace DeliveryDesktop.Models
{
    public class CourierModel : BaseModel<Guid>
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


        public override string ToString()
        {
            return FullName;
        }
    }
}
