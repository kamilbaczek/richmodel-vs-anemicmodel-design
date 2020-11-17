using Microsoft.EntityFrameworkCore;

namespace RichModel.Persistance
{
    public sealed class OrdersDbContextFactory : DesignTimeDbContextFactoryBase<OrdersDbContext>
    {
        protected override OrdersDbContext CreateNewInstance(DbContextOptions<OrdersDbContext> options)
        {
            return new OrdersDbContext(options);
        }
    }
}