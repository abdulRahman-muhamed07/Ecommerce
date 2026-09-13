using Ecommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BusinessRule
{
    public class OrderCanCompleteRule
    {
        public static void Check(OrderStatus currentStatus)
        {
            if (currentStatus != OrderStatus.Delivered)
            {
                throw new InvalidOrderStatusTransitionException(
                    currentStatus,
                    OrderStatus.Completed);
            }
        }
    }
}
