using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class InventoryTransaction : BaseEntity
{
    public Guid WarehouseId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public InventoryTransactionType Type { get; private set; }
    public int Quantity { get; private set; }
    public string? ReferenceType { get; private set; }
    public string? ReferenceId { get; private set; }
}