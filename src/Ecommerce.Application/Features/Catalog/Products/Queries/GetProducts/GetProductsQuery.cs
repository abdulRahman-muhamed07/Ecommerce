using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts
{
    public class GetProductsQuery
    {

        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 20;

    }
}
