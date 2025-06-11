using DeliveryAPI.Data.Models;
using DeliveryAPI.DbFunctionsExtensions;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => PgSqlDbFunctionsExtensions.ToChar(default, string.Empty));
            base.OnModelCreating(modelBuilder);
        }
    }
}
