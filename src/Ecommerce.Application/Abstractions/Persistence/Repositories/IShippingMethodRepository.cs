using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Abstractions.Persistence.Repositories;

public interface IShippingMethodRepository
{
    Task<ShippingMethod?> GetActiveByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}