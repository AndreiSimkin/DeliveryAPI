using DeliveryAPI.Common.Interfaces;

namespace DeliveryAPI.Common.Models
{
    public class SuccessOperationResult : IOperationResult
    {
        public bool Success { get; protected set; } = true;

        public required string Message { get; init; }
    }
}
