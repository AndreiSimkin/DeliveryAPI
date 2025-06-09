using DeliveryAPI.Common.Models;
using DeliveryAPI.Data.Models;
using MediatR;

namespace DeliveryAPI.Queries.Orders
{
    public record GetOrdersQuery : IRequest<PagedResult<OrderEntity>>
    {
        public int PageNumber { get; init; }

        public int PageSize { get; init; }

        public string? Filter { get; init; }
    }
}
