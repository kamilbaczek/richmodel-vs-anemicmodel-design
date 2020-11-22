using System;
using System.Threading.Tasks;
using AnemicModel.Application.Orders;
using AnemicModel.Domain.Orders;
using AnemicModel.Domain.Products;

namespace AnemicModel.Persistance.Features.Orders
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        public Task Create(Order order, Product product)
        {
            throw new NotImplementedException();
        }
    }
}