using Microsoft.EntityFrameworkCore;
using RichModel.Domain.Orders;
using RichModel.Domain.Products;
using RichModel.Persistance.Orders.Configurations;

namespace RichModel.Persistance
{
    public sealed class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options)
        {
        }

        internal DbSet<Order> Orders { get; set; }
        internal DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersEntityConfiguration).Assembly);
        }
    }
}