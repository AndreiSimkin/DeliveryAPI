using AutoMapper;
using DeliveryAPI.Commands.OrderStatus;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using DeliveryAPI.Data.Primitives;
using DeliveryAPI.Queries.OrderStatus;
using MediatR;
using Microsoft.OpenApi.Extensions;

namespace DeliveryAPI.Handlers.Orders.OrderStatus
{
    public class GetOrderStatusListQueryHandler : IRequestHandler<GetOrderStatusListQuery, OrderStatusInfo[]>
    {
        public Task<OrderStatusInfo[]> Handle(GetOrderStatusListQuery request, CancellationToken cancellationToken)
        {
            OrderStatusInfo[] result = Enum.GetValues<OrderStatusEnum>()
                .Select(status => new OrderStatusInfo
                {
                    Id = (int)status,
                    Name = status.ToString(),
                    DisplayName = status.GetDisplayName()
                })
                .ToArray();

            return Task.FromResult(result);
        }
    }
}
