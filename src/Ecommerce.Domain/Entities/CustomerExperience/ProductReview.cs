using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ProductReview : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public Guid ProductId { get; private set; }
    public Guid OrderItemId { get; private set; }
    public int Rating { get; private set; }
    public string? Title { get; private set; }
    public string? Comment { get; private set; }
}