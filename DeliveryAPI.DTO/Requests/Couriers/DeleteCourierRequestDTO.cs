namespace DeliveryAPI.DTO.Requests.Couriers
{
    public record class DeleteCourierRequestDTO
    {
        /// <summary>
        /// Индификатор курьера.
        /// </summary>
        public required Guid Id { get; set; }
    }
}
