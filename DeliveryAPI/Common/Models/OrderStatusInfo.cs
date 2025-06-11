namespace DeliveryAPI.Common.Models
{
    public record OrderStatusInfo
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required string DisplayName { get; init; }
    }
}
