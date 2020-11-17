using System;
using System.Collections.Generic;
using MediatR;

namespace RichModel.Application.Orders.CreateOrder
{
    public sealed class CreateOrderCommand : IRequest
    {
        public IEnumerable<Guid> ProductsIds { get; set; }
    }
}