using Ecommerce.Application.Abstractions.Persistence;
using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Application.Identity;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart;

public sealed class AddToCartHandler
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductVariantRepository _productVariantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IApplicationDbContext _context;

    public AddToCartHandler(
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
        AddToCartCommand command,
        CancellationToken cancellationToken = default)
    {
        var userId = _currentUserService.UserId;

        if (string.IsNullOrWhiteSpace(userId))
            throw new UnauthorizedAccessException();

        if (command.Quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero.");

        var variant = await _productVariantRepository.GetByIdAsync(
            command.ProductVariantId,
            cancellationToken);

        if (variant is null)
            throw new KeyNotFoundException(
                "Product variant was not found.");

        if (variant.StockQuantity < command.Quantity)
            throw new InvalidOperationException(
                "Insufficient stock.");

        var cart = await _cartRepository.GetByUserIdForUpdateAsync(
            userId,
            cancellationToken);

        if (cart is null)
        {
            cart = new Ecommerce.Domain.Entities.Cart(userId);

            cart.AddItem(
                variant.Id,
                command.Quantity,
                variant.Price);

            await _cartRepository.AddAsync(
                cart,
                cancellationToken);
        }
        else
        {
            var existingItem = cart.Items
                .FirstOrDefault(
                    item => item.ProductVariantId == variant.Id);

            if (existingItem is not null &&
                existingItem.Quantity + command.Quantity > variant.StockQuantity)
            {
                throw new InvalidOperationException(
                    "Requested quantity exceeds available stock.");
            }

            cart.AddItem(
                variant.Id,
                command.Quantity,
                variant.Price);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}