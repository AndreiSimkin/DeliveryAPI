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
        public DateTime PickupTime { get; init; }

        /// <summary>
        /// Адрес, куда требуется доставить заказ.
        /// </summary>
        [MaxLength(200)]
        public string? DeliveryAddress { get; init; }
    }
}
