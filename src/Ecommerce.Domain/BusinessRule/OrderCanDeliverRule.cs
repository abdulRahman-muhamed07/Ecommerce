using Ecommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BusinessRule
{
    public class OrderCanDeliverRule
    {
        public static void Check(OrderStatus currentStatus)
        {
            if (currentStatus != OrderStatus.Shipped)
            {
                throw new InvalidOrderStatusTransitionException(
                    currentStatus,
                    OrderStatus.Delivered);
            }
        }
    }
}
