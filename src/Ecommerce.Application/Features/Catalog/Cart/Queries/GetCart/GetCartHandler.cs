using Ecommerce.Application.Abstractions.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Catalog.Cart.Queries.GetCart
{
    public class GetCartHandler
    {


        private readonly ICartRepository _cartRepository;

        public GetCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
    }
}
