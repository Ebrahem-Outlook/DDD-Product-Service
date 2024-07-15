using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid ProductId,
    string Name,
    string Description,
    decimal Price,
    int Stock) : ICommand<Result>;
