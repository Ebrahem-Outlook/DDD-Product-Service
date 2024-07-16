using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Queries.GetAll;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetById;

internal sealed class GetByIdProductQueryHandler(IProductRepository productRepository) 
    : IQueryHandler<GetByIdProductQuery, ProductDTO>
{
    public async Task<ProductDTO> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            return new(string.Empty, string.Empty, default, default);
        }

        return new ProductDTO(
            product.Name.Value, 
            product.Description.Value, 
            product.Price.Value, 
            product.Stock.Value);
    }
}
