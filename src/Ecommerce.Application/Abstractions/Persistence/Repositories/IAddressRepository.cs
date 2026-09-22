using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Abstractions.Persistence.Repositories
{
    public interface IAddressRepository
    {
        Task<Address?> GetByIdForUserAsync(
            Guid addressId,
            string userId,
            CancellationToken cancellationToken = default);
    }
}
