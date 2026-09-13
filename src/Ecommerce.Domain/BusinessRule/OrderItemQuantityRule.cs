using Ecommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BusinessRule
{
    public class OrderItemQuantityRule
    {
        public static void Check(int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOrderItemQuantityException();
            }
        }
    }
}
