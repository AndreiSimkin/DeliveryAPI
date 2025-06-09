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
        public required DateTime PickupTime { get; init; }

        /// <summary>
        /// Адрес, куда требуется доставить заказ.
        /// </summary>
        [MaxLength(200)]
        public required string DeliveryAddress { get; init; }
    }
}
