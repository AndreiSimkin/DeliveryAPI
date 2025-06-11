using CommunityToolkit.Mvvm.ComponentModel;
using DeliveryDesktop.Primitives;
using System.ComponentModel.DataAnnotations;

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
        /// Вес груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public int Weight { get; set; }

        /// <summary>
        /// Длина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required(ErrorMessage = "Длина груза обязателена")]
        public int Length { get; set; }

        /// <summary>
        /// Ширина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required(ErrorMessage = "Ширина груза обязателена")]
        public int Width { get; set; }

        /// <summary>
        /// Высота груза.
        /// </summary>
        [Range(1, 1000)]
        [Required(ErrorMessage = "Высота груза обязателена")]
        public int Height { get; set; }

        /// <summary>
        /// Время закрытия заявки UTC.
        /// </summary>
        public DateTime? ClosedAt { get; set; }
    }
}
