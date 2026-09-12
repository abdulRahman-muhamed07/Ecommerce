using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Shipment : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Guid ShippingMethodId { get; private set; }
    public string? TrackingNumber { get; private set; }
    public string? Carrier { get; private set; }
    public string Status { get; private set; } = "Pending";
    public DateTime? ShippedAt { get; private set; }
    public DateTime? DeliveredAt { get; private set; }
    public ICollection<ShipmentItem> Items { get; private set; } = new List<ShipmentItem>();
}