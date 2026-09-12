using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Promotion : BaseEntity
{
    public string Name { get; private set; } = null!;
    public PromotionType Type { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int Priority { get; private set; }
    public bool IsActive { get; private set; }
}