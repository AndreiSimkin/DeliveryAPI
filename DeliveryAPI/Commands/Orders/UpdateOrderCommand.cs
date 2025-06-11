using DeliveryAPI.Common.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.Commands.Orders
{
    public record UpdateOrderCommand : IRequest<IOperationResult>
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string? ClientName { get; set; }

        /// <summary>
        /// Время, когда нужно забрать заказ.
        /// </summary>
        public DateTime? PickupTime { get; set; }

        /// <summary>
        /// Адрес, откуда требуется забрать заказ.
        /// </summary>
        public string? PickupAddress { get; set; }

        /// <summary>
        /// Вес груза.
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Длина груза.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Ширина груза.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Высота груза.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Адрес, куда требуется доставить заказ.
        /// </summary>
        public string? DeliveryAddress { get; set; }
    }
}
