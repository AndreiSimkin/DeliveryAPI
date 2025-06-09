using DeliveryAPI.Common.Models;
using DeliveryAPI.Data.Models;
using MediatR;

namespace DeliveryAPI.Queries.Couriers
{
    public record GetCouriersQuery : IRequest<PagedResult<CourierEntity>>
    {
        public int PageNumber { get; init; }

        public int PageSize { get; init; }

        public string? Filter { get; init; }
    }
}
