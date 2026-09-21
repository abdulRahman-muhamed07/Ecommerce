using Ecommerce.Application.Abstractions.Persistence;
using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart.UpdateCartItem;
using Ecommerce.Application.Identity;

namespace Ecommerce.Application.Features.Catalog.Cart.Commands.UpdateCartItem;

public sealed class UpdateCartItemHandler
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductVariantRepository _productVariantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IApplicationDbContext _context;

    public UpdateCartItemHandler(
        ICartRepository cartRepository,
        IProductVariantRepository productVariantRepository,
        ICurrentUserService currentUserService,
        IApplicationDbContext context)
    {
        _cartRepository = cartRepository;
        _productVariantRepository = productVariantRepository;
        _currentUserService = currentUserService;
        _context = context;
    }

    public async Task HandleAsync(
        UpdateCartItemCommand command,
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

        var cartItem = cart.Items
            .FirstOrDefault(item => item.Id == command.CartItemId);

        if (cartItem is null)
            throw new KeyNotFoundException(
                "Cart item was not found.");

        var variant = await _productVariantRepository.GetByIdAsync(
            cartItem.ProductVariantId,
            cancellationToken);

        if (variant is null)
            throw new KeyNotFoundException(
                "Product variant was not found.");

        if (variant.StockQuantity < command.Quantity)
            throw new InvalidOperationException(
                "Requested quantity exceeds available stock.");

        cartItem.UpdateQuantity(command.Quantity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}