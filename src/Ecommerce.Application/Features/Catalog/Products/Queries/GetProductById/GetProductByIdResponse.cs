namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;

public sealed record GetProductByIdResponse(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    Guid BrandId,
    Guid CategoryId);