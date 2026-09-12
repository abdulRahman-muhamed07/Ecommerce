namespace Ecommerce.Application.Abstractions;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
