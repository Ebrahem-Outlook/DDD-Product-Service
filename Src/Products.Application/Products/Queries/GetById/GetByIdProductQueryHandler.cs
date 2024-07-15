using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Queries.GetAll;

namespace Products.Application.Products.Queries.GetById;

internal sealed class GetByIdProductQueryHandler : IQueryHandler<GetByIdProductQuery, ProductDTO>
{
    public Task<ProductDTO> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
