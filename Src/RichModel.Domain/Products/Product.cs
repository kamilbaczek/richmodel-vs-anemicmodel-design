using System;
using System.Collections.Generic;
using RichModel.Domain.Orders;

namespace RichModel.Domain.Products
{
    public sealed class Product
    {
        public Guid Id { get; }
        public decimal Price { get; }
        private ICollection<OrderItem> Items { get; set; }
        
        private Product()
        {
        }

        private Product(decimal price)
        {
            Id = Guid.NewGuid();
            Price = price;
        }
        
        public static Product Create(decimal price)
        {
           return new Product(price);
        }
    }
}