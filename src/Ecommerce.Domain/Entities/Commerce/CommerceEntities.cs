using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Address : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Area { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string? Building { get; private set; }
    public string? Floor { get; private set; }
    public string? Apartment { get; private set; }
    public string? PostalCode { get; private set; }
    public bool IsDefault { get; private set; }
}

public sealed class Cart : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();
}

public sealed class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
}

public sealed class Wishlist : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public ICollection<WishlistItem> Items { get; private set; } = new List<WishlistItem>();
}

public sealed class WishlistItem : BaseEntity
{
    public Guid WishlistId { get; private set; }
    public Guid ProductId { get; private set; }
}

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

public sealed class OrderAddress : BaseEntity
{
    public Guid OrderId { get; private set; }
    public AddressType AddressType { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Area { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string? Building { get; private set; }
    public string? Floor { get; private set; }
    public string? Apartment { get; private set; }
    public string? PostalCode { get; private set; }
}

public enum OrderStatus { Pending, Confirmed, Processing, Shipped, Delivered, Cancelled, Completed }
public enum PaymentStatus { Pending, Paid, Failed, Refunded, PartiallyRefunded }
public enum FulfillmentStatus { Unfulfilled, PartiallyFulfilled, Fulfilled }
public enum AddressType { Shipping, Billing }
