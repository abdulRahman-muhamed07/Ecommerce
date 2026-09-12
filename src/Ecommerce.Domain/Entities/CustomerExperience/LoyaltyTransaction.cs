using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class LoyaltyTransaction : BaseEntity
{
    public Guid LoyaltyAccountId { get; private set; }
    public int Points { get; private set; }
    public string Type { get; private set; } = null!;
    public string? ReferenceType { get; private set; }
    public string? ReferenceId { get; private set; }
}