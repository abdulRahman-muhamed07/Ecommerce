using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public class ProductVariantRepository : IProductVariantRepository
{
    private readonly ApplicationDbContext _context;

    public ProductVariantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductVariant?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.ProductVariants
            .AsNoTracking()
            .FirstOrDefaultAsync(
                v => v.Id == id,
                cancellationToken);
    }
}