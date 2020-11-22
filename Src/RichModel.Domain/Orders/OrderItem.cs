using System;
using RichModel.Domain.Products;

namespace RichModel.Domain.Orders
{
    public sealed class OrderItem
    {
        private Guid ProductId { get; }
        internal Product Product { get; }
        
        private Guid OrderId { get; }
        private Order Order { get; }
        
        private OrderItem()
        {
        }

        private OrderItem(Product product, Order order)
        {
            Product = product;
            Order = order;
        }
        
        internal static OrderItem Create(Product product, Order order)
        {
            return new OrderItem(product, order);
        }
    }
}