using Products.Application.Core.Abstractions.Messaging;

namespace Products.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand<string>;
