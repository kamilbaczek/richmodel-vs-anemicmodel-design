using System;

namespace AnemicModel.Domain.Orders
{
    public sealed class Order
    {
        public long Id { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
    }
}