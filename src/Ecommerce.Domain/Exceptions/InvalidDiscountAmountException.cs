namespace Ecommerce.Domain.Exceptions;

public sealed class InvalidDiscountAmountException : DomainRuleException
{
    public InvalidDiscountAmountException()
        : base("Discount amount cannot be negative or exceed the item subtotal.")
    {
    }
}
