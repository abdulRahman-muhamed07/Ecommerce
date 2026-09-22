using Ecommerce.Application.Abstractions.Persistence;
using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Application.Identity;

namespace Ecommerce.Application.Features.Catalog.Cart.Commands.RemoveCartItem;

public sealed class RemoveCartItemHandler
{
    private readonly ICartRepository _cartRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IApplicationDbContext _context;

    public RemoveCartItemHandler(
        ICartRepository cartRepository,
        ICurrentUserService currentUserService,
        IApplicationDbContext context)
    {
        _cartRepository = cartRepository;
        _currentUserService = currentUserService;
        _context = context;
    }

    public async Task HandleAsync(
        RemoveCartItemCommand command,
        CancellationToken cancellationToken = default)
    {
        var userId = _currentUserService.UserId;

        if (string.IsNullOrWhiteSpace(userId))
            throw new UnauthorizedAccessException();

        var cart = await _cartRepository.GetByUserIdForUpdateAsync(
            userId,
            cancellationToken);

        if (cart is null)
            throw new KeyNotFoundException(
                "Cart was not found.");

        cart.RemoveItem(command.CartItemId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}