using System.Collections.Generic;
using RichModel.Domain.Orders;
using NUnit.Framework;
using RichModel.Domain.Orders.Exceptions;
using RichModel.Domain.Products;
using Shouldly;

namespace RichModel.Domain.UnitTests.Orders
{
    public sealed class CreateOrderTest
    {
        [Test]
        public void Given_CreateOrder_When_ProductsAreEmpty_Then_ThrowOrderCannotBeEmptyException()
        {
            var emptyProductList = new List<Product>();

            Should.Throw<OrderCannotBeEmptyException>(
                () => Order.Create(emptyProductList));
        }
        
        [Test]
        public void Given_CreateOrder_When_ProductsAreNotEmpty_Then_NoThrowOrderCannotBeEmptyException()
        {
            var noEmptyProductList = new List<Product>
            {
                Product.Create(10m)
            };

            Should.NotThrow(
                () => Order.Create(noEmptyProductList));
        }
    }
}