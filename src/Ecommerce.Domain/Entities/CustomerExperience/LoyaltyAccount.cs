using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class LoyaltyAccount : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public int CurrentBalance { get; private set; }
    public ICollection<LoyaltyTransaction> Transactions { get; private set; } = new List<LoyaltyTransaction>();
}