using System.Threading;
using System.Threading.Tasks;
using RichModel.Domain.Orders;
using RichModel.Persistance.Database.Configurations;

namespace RichModel.Persistance.Orders.Repositiories
{
    internal sealed class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _context;

        public OrdersRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order order, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}