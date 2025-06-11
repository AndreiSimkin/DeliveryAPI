using DeliveryAPI.Common.Models;
using MediatR;

namespace DeliveryAPI.Queries.OrderStatus
{
    public class GetOrderStatusListQuery : IRequest<OrderStatusInfo[]>
    {
        // Nothing here...
    }
}
