using AnemicModel.Application.Common;
using AnemicModel.Domain.Orders;
using AnemicModel.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace AnemicModel.Persistance
{
    public class OrdersDbContext : DbContext, IOrdersContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}