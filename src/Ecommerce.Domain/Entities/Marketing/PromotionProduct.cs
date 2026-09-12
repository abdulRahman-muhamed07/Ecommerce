using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class PromotionProduct : BaseEntity
{
    public Guid PromotionId { get; private set; }
    public Guid ProductId { get; private set; }
}