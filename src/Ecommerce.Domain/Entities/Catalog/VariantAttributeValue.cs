using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class VariantAttributeValue : BaseEntity
{
    public Guid ProductVariantId { get; private set; }
    public ProductVariant ProductVariant { get; private set; } = null!;
    public Guid AttributeValueId { get; private set; }
    public AttributeValue AttributeValue { get; private set; } = null!;
}