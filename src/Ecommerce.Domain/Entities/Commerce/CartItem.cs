using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public ProductVariant ProductVariant { get; private set; } = null!;

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }




    private CartItem()
    {
    }

    public CartItem(
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero.",
                nameof(quantity));

        if (unitPrice < 0)
            throw new ArgumentException(
                "Unit price cannot be negative.",
                nameof(unitPrice));

        ProductVariantId = productVariantId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero.",
                nameof(quantity));

        Quantity += quantity;
    }


    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero.",
                nameof(quantity));

        Quantity = quantity;
    }
}