using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

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