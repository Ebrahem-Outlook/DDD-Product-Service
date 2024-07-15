using Products.Application.Core.Abstractions.Messaging;

namespace Products.Application.Products.Queries.GetAll;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductDTO>>
{
    public Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
