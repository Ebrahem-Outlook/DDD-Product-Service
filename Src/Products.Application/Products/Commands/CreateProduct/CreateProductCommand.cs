using Products.Application.Core.Abstractions.Messaging;

namespace Products.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock) : ICommand<string>;
