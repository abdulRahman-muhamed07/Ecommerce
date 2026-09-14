using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Contracts
{
    public sealed record GetProductsResponse(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    Guid BrandId,
    Guid CategoryId
);
}
