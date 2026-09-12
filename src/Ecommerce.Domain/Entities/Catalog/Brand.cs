using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class Brand : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public string? LogoUrl { get; private set; }
    public ICollection<Product> Products { get; private set; } = new List<Product>();
}