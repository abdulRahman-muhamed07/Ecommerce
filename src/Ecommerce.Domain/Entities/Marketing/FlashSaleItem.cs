using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class FlashSaleItem : BaseEntity
{
    public Guid FlashSaleId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public decimal SalePrice { get; private set; }
    public int Quantity { get; private set; }
    public int SoldQuantity { get; private set; }
}