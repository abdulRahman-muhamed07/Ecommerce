using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ProductAttribute : BaseEntity
{
    public string Name { get; private set; } = null!;
    public ICollection<AttributeValue> Values { get; private set; } = new List<AttributeValue>();
}