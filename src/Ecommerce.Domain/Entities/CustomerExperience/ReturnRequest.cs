using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ReturnRequest : BaseEntity
{
    public Guid OrderId { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Status { get; private set; } = "Pending";
    public string? Reason { get; private set; }
    public decimal RefundAmount { get; private set; }
    public ICollection<ReturnItem> Items { get; private set; } = new List<ReturnItem>();
}