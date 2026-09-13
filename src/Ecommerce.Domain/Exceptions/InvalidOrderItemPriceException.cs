namespace Ecommerce.Domain.Exceptions;

public sealed class InvalidOrderItemPriceException : DomainRuleException
{
    public InvalidOrderItemPriceException()
        : base("Order item unit price cannot be negative.")
    {
    }
}
