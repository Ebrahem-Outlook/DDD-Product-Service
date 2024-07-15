using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Queries.GetAll;
using System.Data;

namespace Products.Application.Products.Queries.GetByName;

public sealed record GetByNameQuery(string Name) : IQuery<ProductDTO>;

internal sealed record GetByNameQueryHandler : IQueryHandler<GetByNameQuery, ProductDTO>
{
    public Task<ProductDTO> Handle(GetByNameQuery request, CancellationToken cancellationToken)
    { 
        throw new NotImplementedException();
    }
}
