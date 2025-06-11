using DeliveryAPI.DTO.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Requests.Orders
{
    public record UpdateOrderRequestDTO
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        [MaxLength(100)]
        public string? ClientName { get; init; }

        /// <summary>
        /// Адрес, откуда требуется забрать заказ.
        /// </summary>
        [MaxLength(200)]
        public string? PickupAddress { get; init; }

        /// <summary>
        /// Время, когда нужно забрать заказ.
        /// </summary>
        [DateGreaterThanNowUtc]
        public DateTime PickupTime { get; init; }

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
        [Required]
        public required int Length { get; set; }

        /// <summary>
        /// Ширина груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Width { get; set; }

        /// <summary>
        /// Высота груза.
        /// </summary>
        [Range(1, 1000)]
        [Required]
        public required int Height { get; set; }

        /// <summary>
        /// Адрес, куда требуется доставить заказ.
        /// </summary>
        [MaxLength(200)]
        public string? DeliveryAddress { get; init; }
    }
}
