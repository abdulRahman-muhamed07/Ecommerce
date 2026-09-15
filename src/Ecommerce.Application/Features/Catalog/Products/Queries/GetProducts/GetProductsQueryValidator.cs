using FluentValidation;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;

public sealed class GetProductsQueryValidator
    : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100);
    }
}
