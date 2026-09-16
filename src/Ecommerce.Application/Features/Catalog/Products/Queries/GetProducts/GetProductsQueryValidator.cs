using FluentValidation;

namespace Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;

public sealed class GetProductsQueryValidator
    : AbstractValidator<GetProductsQuery>
{
    private static bool BeValidSortOption(string? sortBy)
    {
        return sortBy is
            "name" or
            "name_desc" or
            "price_asc" or
            "price_desc" or
            "newest" or
            "oldest";
    }


    public GetProductsQueryValidator()
    {



        RuleFor(x => x.SortBy)
    .Must(BeValidSortOption)
    .When(x => !string.IsNullOrWhiteSpace(x.SortBy))
    .WithMessage("SortBy must be one of: name, name_desc, price_asc, price_desc, newest, oldest.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.MinPrice)
    .GreaterThanOrEqualTo(0)
    .When(x => x.MinPrice.HasValue);

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxPrice.HasValue);

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(x => x.MinPrice!.Value)
            .When(x => x.MinPrice.HasValue && x.MaxPrice.HasValue);
    }
}
