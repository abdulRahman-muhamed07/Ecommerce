using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class PromotionRule : BaseEntity
{
    public Guid PromotionId { get; private set; }
    public string RuleType { get; private set; } = null!;
    public string Value { get; private set; } = null!;
}