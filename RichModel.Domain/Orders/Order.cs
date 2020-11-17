using System;
using System.Collections.Generic;
using System.Linq;
using RichModel.Domain.Products;

namespace RichModel.Domain.Orders
{
    public sealed class Order
    {
        private const decimal Discount = 0.15m;

        private Order(IEnumerable<Product> products)
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Payed;
            SetItems(products);
        }

        private Order()
        {
        }

        public Guid Id { get; }
        public OrderStatus Status { get; private set; }

        public decimal TotalPrice
        {
            get
            {
                var amount = Items.Select(orderItem => orderItem.Product.Price).Sum();
                if (amount <= 1000) return amount;
                return amount * (1 - Discount);
            }
        }

        private ICollection<OrderItem> Items { get; set; }

        private void SetItems(IEnumerable<Product> products)
        {
            var productsList = products.ToList();
            if (!productsList.Any())
                throw new InvalidOperationException("order cant be empty");
            Items = productsList.Select(product => new OrderItem(product, this)).ToList();
        }

        public static Order Create(IEnumerable<Product> products)
        {
            return new Order(products);
        }

        public void Pay()
        {
            Status = OrderStatus.Payed;
        }
    }
}