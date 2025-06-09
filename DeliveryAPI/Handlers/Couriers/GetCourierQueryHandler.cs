using AutoMapper;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data;
using DeliveryAPI.Data.Models;
using DeliveryAPI.Queries.Couriers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Handlers.Couriers
{
    public class GetCourierQueryHandler : IRequestHandler<GetCouriersQuery, PagedResult<CourierEntity>>
    {
        private readonly AppDbContext _dbContext;

        public GetCourierQueryHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResult<CourierEntity>> Handle(GetCouriersQuery request, CancellationToken cancellationToken)
        {
            var couriersQuery = _dbContext.Couriers
                .Include(c => c.Orders)
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Filter) == false)
                couriersQuery = couriersQuery.Where(x =>
                EF.Functions.ILike(x.FullName, $"%{request.Filter}%") ||
                EF.Functions.ILike(x.PhoneNumber, $"%{request.Filter}%"));

            int totalCount = await couriersQuery.CountAsync(cancellationToken);
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            CourierEntity[] couriers = await couriersQuery
                        .Skip(request.PageSize * (request.PageNumber - 1))
                        .Take(request.PageSize)
                        .ToArrayAsync(cancellationToken);

            return new PagedResult<CourierEntity>()
            {
                Items = couriers,
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                PageCount = totalPages
            };
        }
    }
}
