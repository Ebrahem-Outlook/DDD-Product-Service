using Products.Application.Core.Abstractions.Messaging;

namespace Products.Application.Products.Queries.GetAll;

public sealed record GetAllProductsQuery() : IQuery<List<ProductDTO>>;
