namespace Ecommerce.Domain.Entities;

public enum ProductStatus { Draft, Active, Inactive, Archived }
public enum OrderStatus { Pending, Confirmed, Processing, Shipped, Delivered, Cancelled, Completed }
public enum PaymentStatus { Pending, Paid, Failed, Refunded, PartiallyRefunded }
public enum FulfillmentStatus { Unfulfilled, PartiallyFulfilled, Fulfilled }
public enum AddressType { Shipping, Billing }
public enum InventoryTransactionType { Purchase, Sale, Reservation, Release, Adjustment, Return }
public enum PaymentMethod { Card, CashOnDelivery, Wallet, BankTransfer }
public enum DiscountType { Percentage, FixedAmount }
public enum PromotionType { Percentage, FixedAmount, BuyOneGetOne, FreeShipping }
