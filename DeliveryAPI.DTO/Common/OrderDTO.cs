using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Common
{
    public record OrderDTO
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Время создания заявки.
        /// </summary>
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        [MaxLength(100)]
        public required string ClientName { get; init; }

        /// <summary>
        /// Адрес, откуда требуется забрать груз.
        /// </summary>
        [MaxLength(200)]
        public required string PickupAddress { get; init; }

        /// <summary>
        /// Время, когда нужно забрать груз.
        /// </summary>
        public required DateTime PickupTime { get; init; }

        /// <summary>
        /// Адрес, куда требуется доставить груз.
        /// </summary>
        [MaxLength(200)]
        public required string DeliveryAddress { get; init; }

        /// <summary>
        /// Курьер, который доставляет груз.
        /// </summary>
        public CourierShortDTO? Courier { get; set; }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        public int Status { get; init; }

        /// <summary>
        /// Причина отменты заявки.
        /// </summary>
        [MaxLength(500)]
        public string? CancellationReason { get; init; }

        /// <summary>
        /// Вес груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Weight { get; set; }

        /// <summary>
        /// Длина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required(ErrorMessage = "Длина груза обязателена")]
        public required int Length { get; set; }

        /// <summary>
        /// Ширина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required(ErrorMessage = "Ширина груза обязателена")]
        public required int Width { get; set; }

        /// <summary>
        /// Высота груза.
        /// </summary>
        [Range(1, 1000)]
        [Required(ErrorMessage = "Высота груза обязателена")]
        public required int Height { get; set; }

        /// <summary>
        /// Время закрытия заявки.
        /// </summary>
        public DateTime? ClosedAt { get; init; }
    }
}
