using Ecommerce.Domain.BusinessRule;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Exceptions;

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

    private Order()
    {
    }

    public Order(string orderNumber, string userId)
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
            throw new ArgumentException("Order number is required.", nameof(orderNumber));

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("User id is required.", nameof(userId));

        OrderNumber = orderNumber;
        UserId = userId;
        OrderStatus = OrderStatus.Pending;
        PaymentStatus = PaymentStatus.Pending;
        FulfillmentStatus = FulfillmentStatus.Unfulfilled;
    }

    public void Confirm() => TransitionTo(OrderStatus.Confirmed);

    public void StartProcessing() => TransitionTo(OrderStatus.Processing);

    public void Ship() => TransitionTo(OrderStatus.Shipped);

    public void Deliver()
    {
        OrderCanDeliverRule.Check(OrderStatus);//يعني انا هنا بعمل شيك الاول بالبيزنيس رول
                                              //اللي اسمه  كان دليفر رول وبتشيك الاول ثم احول الحاله عادي 
        OrderStatus = OrderStatus.Delivered;
    }

    public void Complete()
    {
        OrderCanCompleteRule.Check(OrderStatus);
        OrderStatus = OrderStatus.Completed;
    }

    public void Cancel()
    {
        if (OrderStatus is OrderStatus.Shipped or OrderStatus.Delivered or OrderStatus.Completed or OrderStatus.Cancelled)
        {
            throw new InvalidOrderStatusTransitionException(
                OrderStatus,
                OrderStatus.Cancelled);
        }

        OrderStatus = OrderStatus.Cancelled;
    }

    public void AddItem(OrderItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Items.Add(item);
    }

    private void TransitionTo(OrderStatus requestedStatus)
    {
        var valid = (OrderStatus, requestedStatus) switch
        {
            (OrderStatus.Pending, OrderStatus.Confirmed) => true,
            (OrderStatus.Confirmed, OrderStatus.Processing) => true,
            (OrderStatus.Processing, OrderStatus.Shipped) => true,
            _ => false
        };

        if (!valid)
            throw new InvalidOrderStatusTransitionException(OrderStatus, requestedStatus);

        OrderStatus = requestedStatus;
    }
}
