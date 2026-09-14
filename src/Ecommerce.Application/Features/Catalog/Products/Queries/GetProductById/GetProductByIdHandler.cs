using Ecommerce.Application.Abstractions.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById
{
    public class GetProductByIdHandler
    {






        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByIdResponse?> HandleAsync(
            GetProductByIdQuery query,
            CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetByIdAsync(
                query.Id,
                cancellationToken);

            if (product is null)
                return null;

            return new GetProductByIdResponse(
                product.Id,
                product.Name,
                product.Slug,
                product.Description,
                product.BrandId,
                product.CategoryId);
        }





    }
}
