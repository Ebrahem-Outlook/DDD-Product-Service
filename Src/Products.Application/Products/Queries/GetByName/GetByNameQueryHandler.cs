using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Queries.GetAll;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetByName;

internal sealed record GetByNameQueryHandler(IProductRepository productRepository)
    : IQueryHandler<GetByNameQuery, List<ProductDTO>>
{
    public async Task<List<ProductDTO>> Handle(GetByNameQuery request, CancellationToken cancellationToken)
    {
        List<Product>? products = await productRepository.GetByNameAsync(request.Name, cancellationToken);

        if (products is null)
        {
            return [];
        }

        List<ProductDTO> productDTOs = new(products.Count);

        foreach (Product product in products)
        {
            ProductDTO productDTO = new(product.Name.Value, product.Description.Value, product.Price.Value, product.Stock.Value);

            productDTOs.Add(productDTO);
        }

        return productDTOs;
    }
}
