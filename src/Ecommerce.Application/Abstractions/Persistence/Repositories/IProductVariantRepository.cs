using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Abstractions.Persistence.Repositories
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant?> GetByIdAsync(
      Guid id,
      CancellationToken cancellationToken = default);
    }
}
