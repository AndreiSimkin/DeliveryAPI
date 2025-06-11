using AutoMapper;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using DeliveryAPI.DbFunctionsExtensions;
using DeliveryAPI.Queries.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Handlers.Orders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PagedResult<OrderEntity>>
    {
        private readonly AppDbContext _dbContext;

        public GetOrdersQueryHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResult<OrderEntity>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = _dbContext.Orders
                .Include(o => o.Courier)
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Filter) == false)
                ordersQuery = ordersQuery.Where(x =>
                EF.Functions.ILike(x.PickupTime.ToString(), $"%{request.Filter}%") ||
                EF.Functions.ILike(x.ClientName, $"%{request.Filter}%") ||
                EF.Functions.ILike(PgSqlDbFunctionsExtensions.ToChar(x.PickupTime, "DD.MM.YYYY HH24:MI:SS"),
                $"%{request.Filter}%") ||
                EF.Functions.ILike(x.PickupAddress, $"%{request.Filter}%") ||
                EF.Functions.ILike(x.DeliveryAddress, $"%{request.Filter}%") ||
                EF.Functions.ILike(x.CancellationReason ?? string.Empty, $"%{request.Filter}%"));

            int totalCount = await ordersQuery.CountAsync(cancellationToken);
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            OrderEntity[] orders = await ordersQuery
                        .Skip(request.PageSize * (request.PageNumber - 1))
                        .Take(request.PageSize)
                        .OrderByDescending(o => o.CreatedAt)
                        .ToArrayAsync(cancellationToken);

            return new PagedResult<OrderEntity>()
            {
                Items = orders,
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                PageCount = totalPages
            };
        }
    }
}
