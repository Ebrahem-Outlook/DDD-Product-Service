using Microsoft.Extensions.Logging;
using Products.Application.Core.Abstractions.Data;
using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler(IProductRepository repository) : ICommandHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Result<Product?> product = await repository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product.IsFailure)
        {
            Result.Failure(product.Error);
        }

        repository.Delete(product.Value);


        return Result.Success();
    }
}
