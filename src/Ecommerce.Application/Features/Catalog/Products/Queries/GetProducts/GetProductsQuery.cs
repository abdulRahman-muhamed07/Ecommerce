using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts
{
    public class GetProductsQuery
    {
        public Guid? CategoryId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 20;
        public string? SearchTerm { get; init; }
        public string? SortBy { get; init; }
        public decimal? MinPrice { get; init; }

        public decimal? MaxPrice { get; init; }
    }
}
