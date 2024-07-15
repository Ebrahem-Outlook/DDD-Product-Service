using FluentValidation;

namespace Products.Application.Products.Queries.GetById;

internal sealed class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQuery>
{
    public GetByIdProductQueryValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("Product Id can not be null or empty");
    }
}
