using System.Threading.Tasks;
using AnemicModel.Domain.Orders;

namespace AnemicModel.Application.Orders
{
    public interface IOrdersRepository
    {
        Task Create(Order order);
        Task Update(Order order);
    }
}