using Microsoft.Extensions.Logging;
using Products.Application.Core.Abstractions.Data;
using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Logger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, Logger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request ... {@request} :: {DateTime}", typeof(CreateProductCommand), DateTime.UtcNow);

        try
        {
            Product? product = Product.Create(request.Name, request.Description, request.Price, request.Stock);

            await _productRepository.AddAsync(product, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Success request ... {@request} :: {DateTime}", typeof(CreateProductCommand), DateTime.UtcNow);

            return Result.Success();
        }
        catch(Exception)
        {
            _logger.LogError("Failed request ... {@request} :: {DateTime}", typeof(CreateProductCommand), DateTime.UtcNow);

            return Result.Failer(new Error("Produce.InHandleExciption", "Product throw InHandle Exciption dyreing creating."));

            throw;
        }
    }
}
