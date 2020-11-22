using System.Threading;
using System.Threading.Tasks;

namespace RichModel.Domain.Orders
{
    public interface IOrdersRepository
    {
        Task CreateAsync(Order order, CancellationToken cancellationToken = default);
    }
}