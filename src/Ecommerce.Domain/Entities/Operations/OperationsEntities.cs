using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Warehouse : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Location { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;
}

public sealed class InventoryItem : BaseEntity
{
    public Guid WarehouseId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public int Quantity { get; private set; }
    public int ReservedQuantity { get; private set; }
    public int AvailableQuantity => Quantity - ReservedQuantity;
}

public sealed class InventoryTransaction : BaseEntity
{
    public Guid WarehouseId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public InventoryTransactionType Type { get; private set; }
    public int Quantity { get; private set; }
    public string? ReferenceType { get; private set; }
    public string? ReferenceId { get; private set; }
}

public enum InventoryTransactionType { Purchase, Sale, Reservation, Release, Adjustment, Return }

public sealed class Payment : BaseEntity
{
    public Guid OrderId { get; private set; }
    public PaymentMethod Method { get; private set; }
    public PaymentStatus Status { get; private set; }
    public decimal Amount { get; private set; }
    public string Provider { get; private set; } = null!;
    public DateTime? PaidAt { get; private set; }
    public ICollection<PaymentTransaction> Transactions { get; private set; } = new List<PaymentTransaction>();
}

public sealed class PaymentTransaction : BaseEntity
{
    public Guid PaymentId { get; private set; }
    public string TransactionType { get; private set; } = null!;
    public string? ProviderTransactionId { get; private set; }
    public decimal Amount { get; private set; }
    public string Status { get; private set; } = null!;
    public string? ResponseCode { get; private set; }
}

public sealed class Refund : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Guid PaymentId { get; private set; }
    public decimal Amount { get; private set; }
    public string? Reason { get; private set; }
    public string Status { get; private set; } = null!;
}

public enum PaymentMethod { Card, CashOnDelivery, Wallet, BankTransfer }

public sealed class ShippingMethod : BaseEntity
{
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int EstimatedDays { get; private set; }
    public bool IsActive { get; private set; } = true;
}

public sealed class Shipment : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Guid ShippingMethodId { get; private set; }
    public string? TrackingNumber { get; private set; }
    public string? Carrier { get; private set; }
    public string Status { get; private set; } = "Pending";
    public DateTime? ShippedAt { get; private set; }
    public DateTime? DeliveredAt { get; private set; }
}

public sealed class ShipmentItem : BaseEntity
{
    public Guid ShipmentId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Quantity { get; private set; }
}
