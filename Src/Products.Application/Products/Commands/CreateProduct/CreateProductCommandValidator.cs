using FluentValidation;

namespace Products.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Name can not be null or empty.");

        RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("Description can not be null or empty.");

        RuleFor(p => p.Price).NotNull().NotEmpty().WithMessage("Name can not be negative");

        RuleFor(p => p.Stock).NotNull().NotEmpty().WithMessage("Name can not be negative");
    }
}
