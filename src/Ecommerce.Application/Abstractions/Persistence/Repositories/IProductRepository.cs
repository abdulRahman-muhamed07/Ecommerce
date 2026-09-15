using Ecommerce.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ecommerce.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Product?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<(IReadOnlyList<Product> Items, int TotalCount)> GetActiveAsync(
    int pageNumber,
    int pageSize,
        string? searchTerm,
    Guid? categoryId,
    string? sortBy,
           decimal? minPrice,
               decimal? maxPrice,



    CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetByCategoryIdAsync(
        Guid categoryId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Product>> SearchAsync(
        string searchTerm,
        CancellationToken cancellationToken = default);
}