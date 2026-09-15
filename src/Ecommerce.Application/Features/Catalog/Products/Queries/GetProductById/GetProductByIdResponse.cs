namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;

public sealed record GetProductByIdResponse(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    ProductBrandResponse Brand,
    ProductCategoryResponse Category,
    IReadOnlyList<ProductImageResponse> Images,
    IReadOnlyList<ProductVariantResponse> Variants);

public sealed record ProductVariantResponse(
    Guid Id,
    string SKU,
    decimal Price,
    decimal? CompareAtPrice,
    IReadOnlyList<ProductVariantAttributeResponse> Attributes);

public sealed record ProductVariantAttributeResponse(
    Guid AttributeId,
    string AttributeName,
    Guid AttributeValueId,
    string AttributeValue);

public sealed record ProductImageResponse(
    Guid Id,
    string ImageUrl,
    int SortOrder);

public sealed record ProductBrandResponse(
    Guid Id,
    string Name,
    string Slug,
    string? LogoUrl);

public sealed record ProductCategoryResponse(
    Guid Id,
    string Name,
    string Slug);