using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ShippingMethod : BaseEntity
{
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int EstimatedDays { get; private set; }
    public bool IsActive { get; private set; } = true;
}