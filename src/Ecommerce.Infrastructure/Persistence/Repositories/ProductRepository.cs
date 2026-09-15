using Ecommerce.Application.Abstractions.Persistence;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await ProductQuery()
            .FirstOrDefaultAsync(
                x => x.Id == id && x.Status == ProductStatus.Active,
                cancellationToken);
    }

    public async Task<Product?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await ProductQuery()
            .FirstOrDefaultAsync(
                x => x.Slug == slug && x.Status == ProductStatus.Active,
                cancellationToken);
    }

    public async Task<(IReadOnlyList<Product> Items, int TotalCount)> GetActiveAsync(
    int pageNumber,
    int pageSize,
    CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .AsNoTracking()
            .Where(p => p.Status == ProductStatus.Active);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

    public async Task<IReadOnlyList<Product>> GetByCategoryIdAsync(
        Guid categoryId,
        CancellationToken cancellationToken = default)
    {
        return await ProductQuery()
            .Where(x => x.CategoryId == categoryId && x.Status == ProductStatus.Active)
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> SearchAsync(
        string searchTerm,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return Array.Empty<Product>();
        }

        searchTerm = searchTerm.Trim();

        return await ProductQuery()
            .Where(x => x.Status == ProductStatus.Active &&
                        (x.Name.Contains(searchTerm) ||
                         (x.Description != null && x.Description.Contains(searchTerm))))
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    private IQueryable<Product> ProductQuery()
    {
        return _context.Products
            .AsNoTracking()
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .Include(x => x.Variants)
            .Include(x => x.Images);
    }
}
