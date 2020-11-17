using System;

namespace AnemicModel.Domain.Products
{
    public sealed class Product
    {
        private Product()
        {
        }

        private Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
    }
}