using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

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