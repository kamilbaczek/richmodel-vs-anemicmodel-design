using System.Threading;
using System.Threading.Tasks;

namespace RichModel.Domain.Orders
{
    public interface IOrdersRepository
    {
        Task Create(Order order, CancellationToken cancellationToken = default);
    }
}