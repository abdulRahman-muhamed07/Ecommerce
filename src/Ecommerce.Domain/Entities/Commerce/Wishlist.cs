using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Wishlist : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public ICollection<WishlistItem> Items { get; private set; } = new List<WishlistItem>();
}