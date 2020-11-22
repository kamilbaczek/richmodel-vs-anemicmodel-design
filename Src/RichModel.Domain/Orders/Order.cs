using System;
using System.Collections.Generic;
using System.Linq;
using RichModel.Domain.Orders.Exceptions;
using RichModel.Domain.Products;

namespace RichModel.Domain.Orders
{
    public sealed class Order
    {
        private const decimal DiscountPercent = 0.25m;
        private const decimal PriceBoundaryToCalculateDiscount = 1000;

        public Guid Id { get; }
        private OrderStatus Status {  get;  }

        public decimal TotalPrice => CalculateTotalPrice();
        
        private ICollection<OrderItem> Items { get; set; }
        
        private Order()
        {
        }
        
        private Order(List<Product> products)
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Payed;
            var readonlyProducts = products.AsReadOnly();
            SetItems(readonlyProducts);
        }

        public static Order Create(List<Product> products)
        {
            return new Order(products);
        }

        private void SetItems(IReadOnlyCollection<Product> products)
        {
            if (AreProductsEmpty())
                throw new OrderCannotBeEmptyException();
            Items = products.Select(product => OrderItem.Create(product, this)).ToList();

            bool AreProductsEmpty()
            {
                return products is null || !products.Any();
            }
        }
        
        private decimal CalculateTotalPrice()
        {
            var amount = Items.Select(orderItem => orderItem.Product.Price).Sum();
            if (amount <= PriceBoundaryToCalculateDiscount) return amount;
            return amount * (1 - DiscountPercent);
        }
    }
}