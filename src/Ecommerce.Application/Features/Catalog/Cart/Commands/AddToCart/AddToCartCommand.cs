using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart
{
    public class AddToCartCommand
    {
      
        public Guid ProductVariantId { get; init; }
        public int Quantity { get; init; }
    }





}
