using AnemicModel.Domain.Products;

namespace AnemicModel.Domain.Orders
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}