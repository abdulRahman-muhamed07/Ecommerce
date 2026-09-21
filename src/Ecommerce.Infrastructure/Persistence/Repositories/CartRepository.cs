using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cart?> GetByUserIdAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .AsNoTracking()
            .Include(c => c.Items)
                .ThenInclude(i => i.ProductVariant)
                    .ThenInclude(v => v.Product)
            .Include(c => c.Items)
                .ThenInclude(i => i.ProductVariant)
                    .ThenInclude(v => v.AttributeValues)
                        .ThenInclude(av => av.AttributeValue)
                            .ThenInclude(a => a.ProductAttribute)
            .FirstOrDefaultAsync(
                c => c.UserId == userId,
                cancellationToken);
    }

    public async Task<Cart?> GetByUserIdForUpdateAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(
                c => c.UserId == userId,
                cancellationToken);
    }

    public async Task AddAsync(
        Cart cart,
        CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(
            cart,
            cancellationToken);
    }
}