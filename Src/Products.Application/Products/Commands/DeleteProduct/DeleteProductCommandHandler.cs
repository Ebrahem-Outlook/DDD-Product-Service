﻿using Microsoft.Extensions.Logging;
using Products.Application.Core.Abstractions.Data;
using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, string>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteProductCommandHandler> _logger;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ILogger<DeleteProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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

            _productRepository.Delete(product);

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
