namespace DeliveryAPI.DTO.Requests.Orders
{
    public record DeleteOrderRequestDTO
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public required Guid Id { get; set; }
    }
}
