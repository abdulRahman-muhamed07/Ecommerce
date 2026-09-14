namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;

public sealed record GetProductsResponse(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    string BrandName,
    string CategoryName,
    IReadOnlyList<ProductVariantResponse> Variants,
    IReadOnlyList<ProductImageResponse> Images);

public sealed record ProductVariantResponse(
    Guid Id,
    string SKU,
    decimal Price,
    decimal? CompareAtPrice,
    decimal? Weight);

public sealed record ProductImageResponse(
    Guid Id,
    string Url,
    bool IsPrimary);
