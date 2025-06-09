using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Common
{
    public record OrderShortDTO
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
        [MaxLength(200)]
        public required DateTime PickupTime { get; init; }

        /// <summary>
        /// Адрес, куда требуется доставить груз.
        /// </summary>
        [MaxLength(500)]
        public required string DeliveryAddress { get; init; }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        public int Status { get; init; }
    }
}
