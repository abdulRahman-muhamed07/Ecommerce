namespace Ecommerce.Domain.Enums;

public enum FulfillmentStatus { Unfulfilled, PartiallyFulfilled, Fulfilled }
public enum AddressType { Shipping, Billing }
public enum InventoryTransactionType { Purchase, Sale, Reservation, Release, Adjustment, Return }
public enum PaymentMethod { Card, CashOnDelivery, Wallet, BankTransfer }
public enum DiscountType { Percentage, FixedAmount }
public enum PromotionType { Percentage, FixedAmount, BuyOneGetOne, FreeShipping }
