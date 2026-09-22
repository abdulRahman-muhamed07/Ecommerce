using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Features.Commerce.Orders.CreateOrder
{
    public class CreateOrderCommand
    {

        public Guid AddressId { get; init; }
        public Guid ShippingMethodId { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
    }
}
