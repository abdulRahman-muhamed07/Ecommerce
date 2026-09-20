using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Abstractions.Persistence.Repositories
{
    public interface ICartRepository
    {

        Task<Cart?> GetByUserIdAsync(
        string userId,
        CancellationToken cancellationToken = default);
    }
}
