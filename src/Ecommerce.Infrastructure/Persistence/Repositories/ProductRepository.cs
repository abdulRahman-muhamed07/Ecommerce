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
        Guid? categoryId,
        string? searchTerm,
        string? sortBy,
        decimal? minPrice,
        decimal? maxPrice,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .AsNoTracking()
            .Where(p => p.Status == ProductStatus.Active);

        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.Trim();

            query = query.Where(p =>
                p.Name.Contains(searchTerm) ||
                (p.Description != null && p.Description.Contains(searchTerm)));
        }

        if (minPrice.HasValue || maxPrice.HasValue)
        {
            query = query.Where(p =>
                p.Variants.Any(v =>
                    (!minPrice.HasValue || v.Price >= minPrice.Value) &&
                    (!maxPrice.HasValue || v.Price <= maxPrice.Value)));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            sortBy = sortBy.Trim().ToLower();

            query = sortBy switch
            {
                "name" => query.OrderBy(p => p.Name),
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price_asc" => query.OrderBy(p => p.Variants
                       .Where(v => v.StockQuantity > 0)
                         .Select(v => (decimal?)v.Price)
                       .Min() ?? decimal.MaxValue),
                "price_desc" => query.OrderByDescending(p => p.Variants
                            .Where(v => v.StockQuantity > 0)
                    .Select(v => (decimal?)v.Price)
                          .Min() ?? 0),

                "newest" => query.OrderByDescending(p => p.CreatedAt),
                "oldest" => query.OrderBy(p => p.CreatedAt),
                _ => query.OrderBy(p => p.Name)
            };
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

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
                .ThenInclude(x => x.AttributeValues)
                    .ThenInclude(x => x.AttributeValue)
                        .ThenInclude(x => x.ProductAttribute)
            .Include(x => x.Images);
    }
}
