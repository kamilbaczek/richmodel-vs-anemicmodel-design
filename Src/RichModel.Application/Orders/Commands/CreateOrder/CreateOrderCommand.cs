using System;
using System.Collections.Generic;
using MediatR;

namespace RichModel.Application.Orders.Commands.CreateOrder
{
    public sealed class CreateOrderCommand : IRequest
    {
        public IEnumerable<Guid> ProductsIds { get; set; }
    }
}