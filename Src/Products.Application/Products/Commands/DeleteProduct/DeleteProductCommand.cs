using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand<Result>;
