using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Cart.Commands.RemoveCartItem;

public sealed class RemoveCartItemCommand
{
    public Guid CartItemId { get; init; }

    public RemoveCartItemCommand(Guid cartItemId)
    {
        CartItemId = cartItemId;
    }
}
