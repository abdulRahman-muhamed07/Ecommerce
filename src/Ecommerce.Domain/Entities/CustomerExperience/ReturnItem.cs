using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ReturnItem : BaseEntity
{
    public Guid ReturnRequestId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Quantity { get; private set; }
    public string? Reason { get; private set; }
    public string? Condition { get; private set; }
}