using DeliveryAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<CourierEntity> Couriers => Set<CourierEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Nothing here...
        }
    }
}
