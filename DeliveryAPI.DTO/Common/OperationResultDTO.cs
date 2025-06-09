namespace DeliveryAPI.DTO.Common
{
    public record OperationResultDTO
    {
        /// <summary>
        /// Успешность операции.
        /// </summary>
        public bool Success { get; init; }

        /// <summary>
        /// Сообщение о результате выполнения операции.
        /// </summary>
        public string? Message { get; init; }
    }
}
