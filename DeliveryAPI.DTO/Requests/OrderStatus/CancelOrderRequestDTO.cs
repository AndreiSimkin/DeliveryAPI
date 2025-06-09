using System.ComponentModel.DataAnnotations;
namespace DeliveryAPI.DTO.Requests.OrderStatus
{
    public record CancelOrderRequestDTO
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Причина отменты заявки.
        /// </summary>
        [MaxLength(500)]
        public string? CancellationReason { get; init; }
    }
}
