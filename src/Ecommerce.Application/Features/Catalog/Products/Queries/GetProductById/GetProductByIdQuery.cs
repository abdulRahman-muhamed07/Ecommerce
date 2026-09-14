using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id);