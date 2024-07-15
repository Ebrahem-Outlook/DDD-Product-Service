using FluentValidation;

namespace Products.Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Product Name can not be null or empty.");

        RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("Product Description can not be null or empty.");

        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price can not be negative.");

        RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Stock can not be negative.");
    }
}
