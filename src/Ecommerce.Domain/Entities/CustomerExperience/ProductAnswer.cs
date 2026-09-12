using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class ProductAnswer : BaseEntity
{
    public Guid ProductQuestionId { get; private set; }
    public string UserId { get; private set; } = null!;
    public string Answer { get; private set; } = null!;
}