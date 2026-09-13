using Ecommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BusinessRule
{
    public class OrderItemPriceRule
    {
        public static void Check(decimal unitPrice)
        {
            if (unitPrice < 0)
            {
                throw new InvalidOrderItemPriceException();
            }
        }
    }
}
