using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts
{
    public sealed record GetProductsPaginatedResponse(
    IReadOnlyList<GetProductsResponse> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages);
}
