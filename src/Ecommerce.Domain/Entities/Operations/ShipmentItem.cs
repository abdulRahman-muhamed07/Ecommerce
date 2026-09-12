using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ShipmentItem : BaseEntity
{
    public Guid ShipmentId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Quantity { get; private set; }
}