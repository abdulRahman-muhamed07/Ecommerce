using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Exceptions
{
    internal class InvalidOrderItemQuantityException : Exception
    {

        public InvalidOrderItemQuantityException()
       : base("Order item quantity must be greater than zero.")
        {
        }
    }
}
