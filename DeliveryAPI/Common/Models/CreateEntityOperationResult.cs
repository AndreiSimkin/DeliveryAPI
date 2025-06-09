namespace DeliveryAPI.Common.Models
{
    public sealed class CreateEntityOperationResult<TEntityId> : SuccessOperationResult
    {
        public required TEntityId Id { get; init; }
    }
}
