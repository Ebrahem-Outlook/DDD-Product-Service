using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetAll;

internal sealed class GetAllProductsQueryHandler(IProductRepository productRepository) 
    : IQueryHandler<GetAllProductsQuery, List<ProductDTO>>
{
    public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product>? products = await productRepository.GetAllAsync(cancellationToken);

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
