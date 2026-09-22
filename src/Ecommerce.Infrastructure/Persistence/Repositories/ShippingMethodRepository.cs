using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public sealed class ShippingMethodRepository : IShippingMethodRepository
{
    private readonly ApplicationDbContext _context;

    public ShippingMethodRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShippingMethod?> GetActiveByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.ShippingMethods
            .AsNoTracking()
            .FirstOrDefaultAsync(
                shippingMethod =>
                    shippingMethod.Id == id &&
                    shippingMethod.IsActive,
                cancellationToken);
    }
}