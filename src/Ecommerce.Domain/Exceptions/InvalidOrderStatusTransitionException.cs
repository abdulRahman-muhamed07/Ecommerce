using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Exceptions
{
    internal class InvalidOrderStatusTransitionException : Exception
    {
        public InvalidOrderStatusTransitionException(
            OrderStatus currentStatus,
            OrderStatus requestedStatus)
            : base(
                $"Cannot change order status from {currentStatus} to {requestedStatus}.")
        {
        }
    }
}
