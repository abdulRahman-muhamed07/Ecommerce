using Ecommerce.Application.Abstractions.Persistence;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;

public sealed class GetProductsHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductsPaginatedResponse> HandleAsync(
         GetProductsQuery query,
         CancellationToken cancellationToken = default)
    {
        var result = await _productRepository.GetActiveAsync(
     query.PageNumber,
      query.PageSize,
     query.CategoryId,
         query.SearchTerm,
             query.SortBy,
                 query.MinPrice,
                     query.MaxPrice,



     cancellationToken);

        var products = result.Items;
        var totalCount = result.TotalCount;

        var items = products
            .Select(product => new GetProductsResponse(
                product.Id,
                product.Name,
                product.Slug,
                product.Description,
                product.BrandId,
                product.CategoryId))
            .ToList();

        var totalPages = (int)Math.Ceiling(
            (double)totalCount / query.PageSize);

        return new GetProductsPaginatedResponse(
            items,
            query.PageNumber,
            query.PageSize,
            totalCount,
            totalPages);
    }
}