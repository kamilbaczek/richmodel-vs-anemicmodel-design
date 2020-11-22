using Microsoft.EntityFrameworkCore;
using RichModel.Domain.Orders;
using RichModel.Domain.Products;
using RichModel.Persistance.Orders.Configurations;

namespace RichModel.Persistance.Database.Configurations
{
    internal sealed class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options)
        {
        }

        internal DbSet<Order> Orders { get; }
        internal DbSet<Product> Products { get;  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersEntityConfiguration).Assembly);
        }
    }
}