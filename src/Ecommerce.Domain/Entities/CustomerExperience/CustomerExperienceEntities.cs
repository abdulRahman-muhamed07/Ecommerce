using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class LoyaltyAccount : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public int CurrentBalance { get; private set; }
}

public sealed class LoyaltyTransaction : BaseEntity
{
    public Guid LoyaltyAccountId { get; private set; }
    public int Points { get; private set; }
    public string Type { get; private set; } = null!;
    public string? ReferenceType { get; private set; }
    public string? ReferenceId { get; private set; }
}

public sealed class ReturnRequest : BaseEntity
{
    public Guid OrderId { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Status { get; private set; } = "Pending";
    public string? Reason { get; private set; }
    public decimal RefundAmount { get; private set; }
}

public sealed class ReturnItem : BaseEntity
{
    public Guid ReturnRequestId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Quantity { get; private set; }
    public string? Reason { get; private set; }
    public string? Condition { get; private set; }
}

public sealed class ProductReview : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public Guid ProductId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Rating { get; private set; }
    public string? Title { get; private set; }
    public string? Comment { get; private set; }
}

public sealed class ProductQuestion : BaseEntity
{
    public Guid ProductId { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Question { get; private set; } = null!;
}

public sealed class ProductAnswer : BaseEntity
{
    public Guid ProductQuestionId { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Answer { get; private set; } = null!;
}

public sealed class Notification : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public string Type { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Message { get; private set; } = null!;
    public string Channel { get; private set; } = "InApp";
    public bool IsRead { get; private set; }
    public DateTime? SentAt { get; private set; }
}

public sealed class AuditLog : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public string Action { get; private set; } = null!;
    public string EntityName { get; private set; } = null!;
    public string EntityId { get; private set; } = null!;
    public string? OldValues { get; private set; }
    public string? NewValues { get; private set; }
    public string? IpAddress { get; private set; }
}
