using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Contracts
{
    public class ProductDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string Slug { get; init; } = null!;
        public string? Description { get; init; }
        public decimal Price { get; init; }
    }
}
