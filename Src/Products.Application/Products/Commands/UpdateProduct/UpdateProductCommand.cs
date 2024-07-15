using Microsoft.Extensions.Logging;
using Products.Application.Core.Abstractions.Data;
using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock) : ICommand<string>;

internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, string>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateProductCommandHandler> _logger;
}
