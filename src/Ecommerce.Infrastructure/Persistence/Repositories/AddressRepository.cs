using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public  class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Address?> GetByIdForUserAsync(
        Guid addressId,
        string userId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(
                address => address.Id == addressId
                             && address.UserId == userId,
                cancellationToken);
    }
}