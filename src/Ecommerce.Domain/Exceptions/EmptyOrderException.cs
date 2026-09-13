namespace Ecommerce.Domain.Exceptions;

public sealed class EmptyOrderException : DomainRuleException
{
    public EmptyOrderException()
        : base("An order must contain at least one item.")
    {
    }
}
