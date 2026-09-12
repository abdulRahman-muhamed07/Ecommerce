using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ProductQuestion : BaseEntity
{
    public Guid ProductId { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Question { get; private set; } = null!;
}