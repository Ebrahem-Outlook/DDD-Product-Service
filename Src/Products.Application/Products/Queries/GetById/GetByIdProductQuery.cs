using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Queries.GetAll;

namespace Products.Application.Products.Queries.GetById;

public sealed record GetByIdProductQuery(Guid Id) : IQuery<ProductDTO>;
