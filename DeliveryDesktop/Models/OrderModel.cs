using DeliveryDesktop.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryDesktop.Models
{
    public class OrderModel : BaseModel<Guid>
    {
        /// <summary>
        /// Время создания заявки.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Имя клиента.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string ClientName { get; set; }

        /// <summary>
        /// Адрес, откуда требуется забрать груз.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public required string PickupAddress { get; set; }

        /// <summary>
        /// Время, когда нужно забрать груз.
        /// </summary>
        [Required]
        public required DateTime PickupTime { get; set; }

        /// <summary>
        /// Адрес, куда требуется доставить груз.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public required string DeliveryAddress { get; set; }

        /// <summary>
        /// Курьер, который доставляет груз.
        /// </summary>
        public CourierModel? Courier { get; set; }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        [Required]
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.New;

        /// <summary>
        /// Причина отменты заявки.
        /// </summary>
        [MaxLength(500)]
        public string? CancellationReason { get; set; }

        /// <summary>
        /// Время закрытия заявки UTC.
        /// </summary>
        public DateTime? ClosedAt { get; set; }
    }
}
