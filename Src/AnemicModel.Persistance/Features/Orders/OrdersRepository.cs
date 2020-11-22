using System;
using System.Threading.Tasks;
using AnemicModel.Application.Orders;
using AnemicModel.Domain.Orders;

namespace AnemicModel.Persistance.Features.Orders
{
    public class OrdersRepository : IOrdersRepository
    {
        public Task Create(Order order)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}