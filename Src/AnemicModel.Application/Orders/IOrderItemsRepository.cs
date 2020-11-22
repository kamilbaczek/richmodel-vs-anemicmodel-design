using System.Threading.Tasks;
using AnemicModel.Domain.Orders;
using AnemicModel.Domain.Products;

namespace AnemicModel.Application.Orders
{
    public interface IOrderItemsRepository
    {
        Task Create(Order order, Product product);
    }
}