using DeliveryAPI.Data.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryAPI.Data.Models
{
    public class OrderDetailsEntity : BaseEntity<Guid>
    {
        /// <summary>
        /// Причина отменты заявки.
        /// </summary>
        [MaxLength(500)]
        public string? CancellationReason { get; set; }
    }
}
