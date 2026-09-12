using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class AttributeValue : BaseEntity
{
    public Guid ProductAttributeId { get; private set; }
    public ProductAttribute ProductAttribute { get; private set; } = null!;
    public string Value { get; private set; } = null!;
}