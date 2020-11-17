using System;
using System.Collections.Generic;
using RichModel.Domain.Orders;

namespace RichModel.Domain.Products
{
    public sealed class Product
    {
        private Product()
        {
        }

        private Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
    }
}