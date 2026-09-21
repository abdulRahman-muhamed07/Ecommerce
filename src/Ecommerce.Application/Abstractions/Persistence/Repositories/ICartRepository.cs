using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Abstractions.Persistence.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdForUpdateAsync(
    string userId,
    CancellationToken cancellationToken = default);
        Task<Cart?> GetByUserIdAsync(
        string userId,
        CancellationToken cancellationToken = default);

        Task AddAsync(
            Cart cart,
            CancellationToken cancellationToken = default);
    }
}
