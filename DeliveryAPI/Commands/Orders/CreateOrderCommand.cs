using DeliveryAPI.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.Commands.Orders
{
    public record CreateOrderCommand : IRequest<CreateEntityOperationResult<Guid>>
    {
        /// <summary>
        /// Имя клиента.
        /// </summary>
        public required string ClientName { get; set; }

        /// <summary>
        /// Время, когда нужно забрать заказ.
        /// </summary>
        [Required]
        public required DateTime PickupTime { get; set; }

        /// <summary>
        /// Адрес, откуда требуется забрать заказ.
        /// </summary>
        public required string PickupAddress { get; set; }

        /// <summary>
        /// Адрес, куда требуется доставить заказ.
        /// </summary>
        public required string DeliveryAddress { get; set; }
    }
}
