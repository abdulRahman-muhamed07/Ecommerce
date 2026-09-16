using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ProductVariant : BaseEntity
{
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;
    public string SKU { get; private set; } = null!;
    public decimal Price { get; private set; }
    public decimal? CompareAtPrice { get; private set; }
    public decimal? CostPrice { get; private set; }
    public string? Barcode { get; private set; }
    public decimal? Weight { get; private set; }

    public int StockQuantity { get; private set; }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        StockQuantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (StockQuantity < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        StockQuantity -= quantity;
    }
    public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();
    public ICollection<VariantAttributeValue> AttributeValues { get; private set; } = new List<VariantAttributeValue>();
}