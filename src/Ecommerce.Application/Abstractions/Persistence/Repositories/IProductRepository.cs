using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Abstractions.Persistence.Repositories
{
    public interface IProductRepository
    {

        Task<IReadOnlyList<Product>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<Product?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Product?> GetBySlugAsync(
            string slug,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Product>> SearchAsync(
            string searchTerm,
            CancellationToken cancellationToken = default);

        Task<int> CountAsync(
            CancellationToken cancellationToken = default);
    }
}
