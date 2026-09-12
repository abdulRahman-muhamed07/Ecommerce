using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Order : BaseEntity
{
    public string OrderNumber { get; private set; } = null!;
    public string UserId { get; private set; } = null!;
    public OrderStatus OrderStatus { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public FulfillmentStatus FulfillmentStatus { get; private set; }
    public decimal Subtotal { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal ShippingAmount { get; private set; }
    public decimal TaxAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; } = "EGP";
    public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();
    public ICollection<OrderAddress> Addresses { get; private set; } = new List<OrderAddress>();
}