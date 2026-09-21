using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Cart : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();


    private Cart()
    {
    }

    public Cart(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException(
                "User id is required.",
                nameof(userId));

        UserId = userId;
    }

    public void AddItem(
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero.",
                nameof(quantity));

        var existingItem = Items
            .FirstOrDefault(x => x.ProductVariantId == productVariantId);

        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
            return;
        }

        Items.Add(
            new CartItem(
                productVariantId,
                quantity,
                unitPrice));
    }
}