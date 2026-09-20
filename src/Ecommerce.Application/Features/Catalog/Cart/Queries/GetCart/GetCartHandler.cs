using Ecommerce.Application.Abstractions.Persistence.Repositories;
using Ecommerce.Application.Identity;

namespace Ecommerce.Application.Features.Catalog.Cart.Queries.GetCart;

public sealed class GetCartHandler
{
    private readonly ICartRepository _cartRepository;
    private readonly ICurrentUserService _currentUserService;

    public GetCartHandler(
        ICartRepository cartRepository,
        ICurrentUserService currentUserService)
    {
        _cartRepository = cartRepository;
        _currentUserService = currentUserService;
    }

    public async Task<GetCartResponse?> HandleAsync(
        GetCartQuery query,
        CancellationToken cancellationToken = default)
    {
        var userId = _currentUserService.UserId;

        if (string.IsNullOrWhiteSpace(userId))
            return null;

        var cart = await _cartRepository.GetByUserIdAsync(
            userId,
            cancellationToken);

        if (cart is null)
            return null;

        var items = cart.Items
            .Select(item => new GetCartItemResponse(
                item.Id,
                item.ProductVariantId,
                item.ProductVariant.Product.Name,
                item.Quantity,
                item.UnitPrice,
                item.UnitPrice * item.Quantity,
                item.ProductVariant.AttributeValues
                    .Select(attributeValue => new CartItemAttributeResponse(
                        attributeValue.AttributeValue.ProductAttribute.Name,
                        attributeValue.AttributeValue.Value))
                    .ToList()))
            .ToList();

        var total = items.Sum(item => item.Total);

        return new GetCartResponse(
            cart.Id,
            items,
            total);
    }
}