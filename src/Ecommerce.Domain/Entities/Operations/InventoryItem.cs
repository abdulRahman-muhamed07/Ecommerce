using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class InventoryItem : BaseEntity
{
    public Guid WarehouseId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public int Quantity { get; private set; }
    public int ReservedQuantity { get; private set; }
    public int AvailableQuantity => Quantity - ReservedQuantity;
}