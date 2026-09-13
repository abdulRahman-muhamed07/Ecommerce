using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Exceptions
{
    internal class InvalidDiscountAmountException : Exception
    {
        public InvalidDiscountAmountException()
            : base("Discount amount cannot exceed the item subtotal.")
        {
        }
    }
}
