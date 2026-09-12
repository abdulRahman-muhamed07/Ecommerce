using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Coupon : BaseEntity
{
    public string Code { get; private set; } = null!;
    public DiscountType DiscountType { get; private set; }
    public decimal DiscountValue { get; private set; }
    public decimal? MinimumOrderAmount { get; private set; }
    public decimal? MaximumDiscountAmount { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int? UsageLimit { get; private set; }
    public int UsedCount { get; private set; }
}

public sealed class CouponUsage : BaseEntity
{
    public Guid CouponId { get; private set; }
    public string UserId { get; private set; } = null!;
    public Guid OrderId { get; private set; }
}

public sealed class Promotion : BaseEntity
{
    public string Name { get; private set; } = null!;
    public PromotionType Type { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int Priority { get; private set; }
    public bool IsActive { get; private set; }
}

public sealed class PromotionProduct : BaseEntity
{
    public Guid PromotionId { get; private set; }
    public Guid ProductId { get; private set; }
}

public sealed class PromotionCategory : BaseEntity
{
    public Guid PromotionId { get; private set; }
    public Guid CategoryId { get; private set; }
}

public sealed class PromotionRule : BaseEntity
{
    public Guid PromotionId { get; private set; }
    public string RuleType { get; private set; } = null!;
    public string Value { get; private set; } = null!;
}

public sealed class FlashSale : BaseEntity
{
    public string Name { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }
}

public sealed class FlashSaleItem : BaseEntity
{
    public Guid FlashSaleId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public decimal SalePrice { get; private set; }
    public int Quantity { get; private set; }
    public int SoldQuantity { get; private set; }
}

public enum DiscountType { Percentage, FixedAmount }
public enum PromotionType { Percentage, FixedAmount, BuyOneGetOne, FreeShipping }
