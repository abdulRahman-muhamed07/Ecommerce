using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Warehouse : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Location { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;
}