using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Payment : BaseEntity
{
    public Guid OrderId { get; private set; }
    public PaymentMethod Method { get; private set; }
    public PaymentStatus Status { get; private set; }
    public decimal Amount { get; private set; }
    public string Provider { get; private set; } = null!;
    public DateTime? PaidAt { get; private set; }
    public ICollection<PaymentTransaction> Transactions { get; private set; } = new List<PaymentTransaction>();
}