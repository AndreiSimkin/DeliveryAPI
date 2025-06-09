namespace DeliveryAPI.DTO.Common
{
    public record CreateEntityOperationResultDTO<TEntityId>
    {
        /// <summary>
        /// Идификатор соданой сущности.
        /// </summary>
        public required TEntityId Id { get; init; }

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
