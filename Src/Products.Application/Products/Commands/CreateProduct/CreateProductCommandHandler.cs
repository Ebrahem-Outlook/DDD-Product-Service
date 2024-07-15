using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Products;
using Products.Domain.Products.ValueObjects;

namespace Products.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler(IProductRepository repository) 
    : ICommandHandler<CreateProductCommand, Result>
{
    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Result<Name> name = Name.Create(request.Name);
        Result<Description> description = Description.Create(request.Name);
        Result<Price> price = Price.Create(request.Price);
        Result<Stock> stock = Stock.Create(request.Stock);
        

        Result<Product> product = Product.Create(name.Value, description.Value, price.Value, stock.Value);

        if (product.IsFailer)
        {
            return Result.Failer(product.Error);
        }

        await repository.AddAsync(product.Value);

        return Result.Success();
    }
}
