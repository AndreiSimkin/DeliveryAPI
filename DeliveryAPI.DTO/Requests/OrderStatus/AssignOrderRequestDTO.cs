namespace DeliveryAPI.DTO.Requests.OrderStatus
{
    public record AssignOrderRequestDTO
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Индификатор курьера.
        /// </summary>
        public required Guid CourierId { get; init; }
    }
}
