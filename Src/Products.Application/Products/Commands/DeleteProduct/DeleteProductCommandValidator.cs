using FluentValidation;

namespace Products.Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.ProductId).NotNull().NotEmpty().WithMessage("ProductId Can not be null or empty.");
    }
}
