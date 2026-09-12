using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Refund : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Guid PaymentId { get; private set; }
    public decimal Amount { get; private set; }
    public string? Reason { get; private set; }
    public string Status { get; private set; } = null!;
}