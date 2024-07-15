using FluentValidation;

namespace Products.Application.Products.Queries.GetByName;

internal sealed class GetByNameQueryValidator : AbstractValidator<GetByNameQuery>
{
    public GetByNameQueryValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Product Name can not be null or empty.");
    }
}
