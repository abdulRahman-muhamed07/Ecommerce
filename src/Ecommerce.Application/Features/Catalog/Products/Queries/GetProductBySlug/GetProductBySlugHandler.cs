using Ecommerce.Application.Abstractions.Persistence;
using Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProductBySlug
{
    public class GetProductBySlugHandler
    {

        private readonly IProductRepository _productRepository;
        public GetProductBySlugHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<GetProductByIdResponse?> HandleAsync(
       GetProductBySlugQuery query,
       CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetBySlugAsync(
                query.Slug,
                cancellationToken);

            if (product is null)
                return null;

            return new GetProductByIdResponse(
                product.Id,
                product.Name,
                product.Slug,
                product.Description,

                new ProductBrandResponse(
                    product.Brand.Id,
                    product.Brand.Name,
                    product.Brand.Slug,
                    product.Brand.LogoUrl),

                new ProductCategoryResponse(
                    product.Category.Id,
                    product.Category.Name,
                    product.Category.Slug),

                product.Images
                    .OrderBy(image => image.SortOrder)
                    .Select(image => new ProductImageResponse(
                        image.Id,
                        image.ImageUrl,
                        image.SortOrder))
                    .ToList(),

               product.Variants
    .Select(variant => new ProductVariantResponse(
        variant.Id,
        variant.SKU,
        variant.Price,
        variant.StockQuantity > 0,
        variant.CompareAtPrice,

        variant.AttributeValues
            .Select(attributeValue => new ProductVariantAttributeResponse(
                attributeValue.AttributeValue.ProductAttributeId,
                attributeValue.AttributeValue.ProductAttribute.Name,
                attributeValue.AttributeValueId,
                variant.StockQuantity,
                attributeValue.AttributeValue.Value))
            .ToList()))
    .ToList());
        }






    }
}
