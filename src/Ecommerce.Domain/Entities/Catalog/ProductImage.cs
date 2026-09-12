using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ProductImage : BaseEntity
{
    public Guid ProductId { get; private set; }
    public Guid? VariantId { get; private set; }
    public string ImageUrl { get; private set; } = null!;
    public int SortOrder { get; private set; }
    public bool IsPrimary { get; private set; }
}