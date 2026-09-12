using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class PromotionCategory : BaseEntity
{
    public Guid PromotionId { get; private set; }
    public Guid CategoryId { get; private set; }
}