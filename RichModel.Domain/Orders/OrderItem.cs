using System;
using RichModel.Domain.Products;

namespace RichModel.Domain.Orders
{
    public sealed class OrderItem
    {
        private OrderItem()
        {
        }

        internal OrderItem(Product product, Order order)
        {
            Product = product;
            Order = order;
        }

        private Guid OrderId { get; }
        private Guid ProductId { get; }

        internal Product Product { get; }
        private Order Order { get; }
    }
}