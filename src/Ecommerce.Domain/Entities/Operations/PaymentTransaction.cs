using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class PaymentTransaction : BaseEntity
{
    public Guid PaymentId { get; private set; }
    public string TransactionType { get; private set; } = null!;
    public string? ProviderTransactionId { get; private set; }
    public decimal Amount { get; private set; }
    public string Status { get; private set; } = null!;
    public string? ResponseCode { get; private set; }
}