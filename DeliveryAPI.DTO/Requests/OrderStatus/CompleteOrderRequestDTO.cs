namespace DeliveryAPI.DTO.Requests.OrderStatus
{
    public record CompleteOrderRequestDTO
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; init; }
    }
}
