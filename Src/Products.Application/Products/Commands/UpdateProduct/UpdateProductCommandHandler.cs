using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Products;
using Products.Domain.Products.ValueObjects;

namespace Products.Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandHandler(IProductRepository repository) : ICommandHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Result<Name> name = Name.Create(request.Name);

        Result<Description> description = Description.Create(request.Description);

        Result<Price> price = Price.Create(request.Price);

        Result<Stock> stock = Stock.Create(request.Stock);

        return Result.Success();

    }

}
