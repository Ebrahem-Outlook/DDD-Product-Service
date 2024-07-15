using Microsoft.Extensions.Logging;
using Products.Application.Core.Abstractions.Data;
using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Commands.DeleteProduct;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, string>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ILogger<UpdateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request ... {@request} :: {DateTime}", typeof(DeleteProductCommand), DateTime.UtcNow);

        try
        {
            Product? product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product is null)
            {
                _logger.LogError("Product with the spicified Id : {@ProductId} was not found {@DateTime}", request.ProductId, DateTime.UtcNow);

                return "Failed";
            }

            product.Update(request.Name, request.Description, request.Price, request.Stock);

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Success request ... {@request} :: {DateTime}", typeof(DeleteProductCommand), DateTime.UtcNow);

            return "Success";
        }
        catch (Exception)
        {
            _logger.LogError("Failed request ... {@request} :: {DateTime}", typeof(DeleteProductCommand), DateTime.UtcNow);

            throw;
        }
    }
}
