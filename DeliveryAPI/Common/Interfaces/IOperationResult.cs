namespace DeliveryAPI.Common.Interfaces
{
    public interface IOperationResult
    {
        public bool Success { get; }

        public string? Message { get; }
    }
}
