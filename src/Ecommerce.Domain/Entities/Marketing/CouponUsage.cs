using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class CouponUsage : BaseEntity
{
    public Guid CouponId { get; private set; }
    public string UserId { get; private set; } = null!;
    public Guid OrderId { get; private set; }
}