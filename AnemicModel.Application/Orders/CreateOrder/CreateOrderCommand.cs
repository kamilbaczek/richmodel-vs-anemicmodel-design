using System;
using System.Collections.Generic;
using MediatR;

namespace AnemicModel.Application.Orders.CreateOrder
{
    public sealed class CreateOrderCommand : IRequest
    {
        public IEnumerable<Guid> ProductsIds { get; set; }
    }
}