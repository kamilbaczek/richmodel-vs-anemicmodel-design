using Microsoft.EntityFrameworkCore;

namespace RichModel.Persistance.Database.Configurations
{
    internal sealed class OrdersDbContextFactory : DesignTimeDbContextFactoryBase<OrdersDbContext>
    {
        protected override OrdersDbContext CreateNewInstance(DbContextOptions<OrdersDbContext> options)
        {
            return new OrdersDbContext(options);
        }
    }
}