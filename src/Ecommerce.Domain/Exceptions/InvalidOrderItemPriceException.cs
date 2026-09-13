using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Exceptions
{
    internal class InvalidOrderItemPriceException : Exception
    {
        public InvalidOrderItemPriceException()
            : base("Order item unit price cannot be negative.")
        {
        }
    }
}
