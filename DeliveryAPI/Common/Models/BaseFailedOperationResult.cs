using DeliveryAPI.Common.Interfaces;

namespace DeliveryAPI.Common.Models
{
    public abstract class BaseFailedOperationResult : IOperationResult
    {
        public bool Success { get; protected set; } = false;

        public required string Message { get; init; }
    }
}
