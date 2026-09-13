using Ecommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BusinessRule
{
    public class OrderMustHaveItemsRule
    {

        public static void Check(int itemCount)
        {
            if (itemCount <= 0)
            {
                throw new EmptyOrderException();
            }
        }
    }
}
