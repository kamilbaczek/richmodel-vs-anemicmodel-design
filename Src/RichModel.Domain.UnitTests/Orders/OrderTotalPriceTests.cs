using System.Collections.Generic;
using NUnit.Framework;
using RichModel.Domain.Orders;
using RichModel.Domain.Products;
using Shouldly;

namespace RichModel.Domain.UnitTests.Orders
{
    public class OrderTotalPriceTests
    {
        private static object[] _orderDiscountNotCountedCases =
        {
            new object[] { 999.0m, 1.0m, 1000m },
            new object[] { 555.0m, 445.0m, 1000m },
            new object[] { 333.0m, 333.3m, 666.3m }
        };
        [TestCaseSourceAttribute(nameof(_orderDiscountNotCountedCases))]
        public void Given_GetTotalPrice_When_ProductsPriceAmountLessenThanPriceBoundaryToCalculateDiscount_Then_DiscountIsNotCounted
            (decimal firstProductPrice, decimal secondProductPrice, decimal expectedOrderTotalPrice)
        {
            var products = new List<Product>
            {
                Product.Create(firstProductPrice),
                Product.Create(secondProductPrice),
            };
            var order = Order.Create(products);
            
            var orderTotalPrice = order.TotalPrice;

            orderTotalPrice.ShouldBe(expectedOrderTotalPrice);
        }
        
        private static object[] _orderDiscountCountedCases =
        {
            new object[] { 2000.0m, 1000.0m, 2250m },
            new object[] { 2500.0m, 1500.0m, 3000m },
            new object[] { 999.0m, 2.0m, 750.75m },
        };
        [TestCaseSourceAttribute(nameof(_orderDiscountCountedCases))]
        public void Given_GetTotalPrice_When_ProductsPriceAmountGreaterThanPriceBoundaryToCalculateDiscount_Then_DiscountIsCounted
            (decimal firstProductPrice, decimal secondProductPrice, decimal expectedOrderTotalPrice)
        {
            var products = new List<Product>
            {
                Product.Create(firstProductPrice),
                Product.Create(secondProductPrice),
            };
            var order = Order.Create(products);
            
            var orderTotalPrice = order.TotalPrice;

            orderTotalPrice.ShouldBe(expectedOrderTotalPrice);
        }
    }
}