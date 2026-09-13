namespace Ecommerce.Domain.Exceptions;

public sealed class InvalidOrderItemQuantityException : DomainRuleException
{
    public InvalidOrderItemQuantityException()
        : base("Order item quantity must be greater than zero.")
    {
    }
}
