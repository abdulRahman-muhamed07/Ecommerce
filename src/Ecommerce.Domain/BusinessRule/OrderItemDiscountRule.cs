using Ecommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BusinessRule
{
    public class OrderItemDiscountRule
    {
        public static void Check(
       decimal discountAmount,
       decimal subtotal)
        {
            if (discountAmount < 0 || discountAmount > subtotal)
            {
                throw new InvalidDiscountAmountException();
            }
        }
    }
}

