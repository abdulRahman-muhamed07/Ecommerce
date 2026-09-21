using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart.UpdateCartItem
{
    public class UpdateCartItemCommand
    {

        public Guid CartItemId { get; init; }
        public int Quantity { get; init; }

    }
}
