using DeliveryAPI.DTO.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Requests.Orders
{
    public record CreateOrderRequestDTO
    {
        /// <summary>
        /// Имя клиента.
        /// </summary>
        [MaxLength(100)]
        public required string ClientName { get; init; }

        /// <summary>
        /// Адрес, откуда требуется забрать заказ.
        /// </summary>
        [MaxLength(200)]
        public required string PickupAddress { get; init; }

        /// <summary>
        /// Время, когда нужно забрать заказ.
        /// </summary>
        [DateGreaterThanNowUtc]
        public required DateTime PickupTime { get; init; }

        /// <summary>
        /// Вес груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Weight { get; init; }

        /// <summary>
        /// Длина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Length { get; init; }

        /// <summary>
        /// Ширина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Width { get; init; }

        /// <summary>
        /// Высота груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Height { get; init; }

        /// <summary>
        /// Адрес, куда требуется доставить заказ.
        /// </summary>
        [MaxLength(200)]
        public required string DeliveryAddress { get; init; }
    }
}
