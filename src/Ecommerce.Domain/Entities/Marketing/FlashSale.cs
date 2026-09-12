using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class FlashSale : BaseEntity
{
    public string Name { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }
}