using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public ProductVariant ProductVariant { get; private set; } = null!;

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
}