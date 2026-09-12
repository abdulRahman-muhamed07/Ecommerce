using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Cart : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();
}