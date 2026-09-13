using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Exceptions;

public sealed class InvalidOrderStatusTransitionException : DomainRuleException
{
    public InvalidOrderStatusTransitionException(
        OrderStatus currentStatus,
        OrderStatus requestedStatus)
        : base($"Cannot change order status from {currentStatus} to {requestedStatus}.")
    {
    }
}
