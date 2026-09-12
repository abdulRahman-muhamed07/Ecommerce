using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public string? Description { get; private set; }
    public Guid? ParentCategoryId { get; private set; }
    public Category? ParentCategory { get; private set; }
    public ICollection<Category> Children { get; private set; } = new List<Category>();
    public ICollection<Product> Products { get; private set; } = new List<Product>();
}

public sealed class Brand : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public string? LogoUrl { get; private set; }
    public ICollection<Product> Products { get; private set; } = new List<Product>();
}

public sealed class Product : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public string? Description { get; private set; }
    public ProductStatus Status { get; private set; }
    public Guid BrandId { get; private set; }
    public Brand Brand { get; private set; } = null!;
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
    public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();
    public ICollection<ProductReview> Reviews { get; private set; } = new List<ProductReview>();
}

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
    public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();
    public ICollection<VariantAttributeValue> AttributeValues { get; private set; } = new List<VariantAttributeValue>();
}

public sealed class ProductImage : BaseEntity
{
    public Guid ProductId { get; private set; }
    public Guid? VariantId { get; private set; }
    public string ImageUrl { get; private set; } = null!;
    public int SortOrder { get; private set; }
    public bool IsPrimary { get; private set; }
}

public sealed class ProductAttribute : BaseEntity
{
    public string Name { get; private set; } = null!;
    public ICollection<AttributeValue> Values { get; private set; } = new List<AttributeValue>();
}

public sealed class AttributeValue : BaseEntity
{
    public Guid ProductAttributeId { get; private set; }
    public ProductAttribute ProductAttribute { get; private set; } = null!;
    public string Value { get; private set; } = null!;
}

public sealed class VariantAttributeValue : BaseEntity
{
    public Guid ProductVariantId { get; private set; }
    public ProductVariant ProductVariant { get; private set; } = null!;
    public Guid AttributeValueId { get; private set; }
    public AttributeValue AttributeValue { get; private set; } = null!;
}

public enum ProductStatus { Draft, Active, Inactive, Archived }
