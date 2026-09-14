using Ecommerce.Application.Abstractions.Persistence;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;

public sealed class GetProductsHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<GetProductsResponse>> HandleAsync(
        GetProductsQuery query,
        CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetActiveAsync(
            cancellationToken);

        return products
            .Select(product => new GetProductsResponse(
                product.Id,
                product.Name,
                product.Slug,
                product.Description,
                product.BrandId,
                product.CategoryId))
            .ToList();
    }
}