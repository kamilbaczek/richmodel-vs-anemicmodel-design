using System;

namespace RichModel.Domain.Orders.Exceptions
{
    public sealed class OrderCannotBeEmptyException : Exception
    {
        private new const string Message = "Order cannot be empty";
       
        internal OrderCannotBeEmptyException() : base(Message)
        {
        }
    }
}