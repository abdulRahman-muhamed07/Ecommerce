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
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Product?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await ProductQuery()
            .FirstOrDefaultAsync(x => x.Slug == slug, cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await ProductQuery()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetActiveAsync(
        CancellationToken cancellationToken = default)
    {
        return await ProductQuery()
            .Where(x => x.Status == ProductStatus.Active)
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
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

    public async Task<bool> ExistsBySlugAsync(
        string slug,
        Guid? excludingId = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .AsNoTracking()
            .Where(x => x.Slug == slug);

        if (excludingId.HasValue)
        {
            query = query.Where(x => x.Id != excludingId.Value);
        }

        return await query.AnyAsync(cancellationToken);
    }

    public async Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
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
