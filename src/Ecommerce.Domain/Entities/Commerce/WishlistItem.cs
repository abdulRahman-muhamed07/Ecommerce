using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class WishlistItem : BaseEntity
{
    public Guid WishlistId { get; private set; }
    public Guid ProductId { get; private set; }
}