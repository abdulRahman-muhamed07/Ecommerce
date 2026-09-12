using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class OrderItem : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public string ProductName { get; private set; } = null!;
    public string SKU { get; private set; } = null!;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal TaxAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
}