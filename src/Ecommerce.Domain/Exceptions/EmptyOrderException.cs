using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public EmptyOrderException()
            : base("An order must contain at least one item.")
        {
        }
    }
}
