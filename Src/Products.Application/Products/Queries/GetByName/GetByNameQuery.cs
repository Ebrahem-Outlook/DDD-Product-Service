using Products.Application.Core.Abstractions.Messaging;
using Products.Application.Products.Queries.GetAll;
using System.Data;

namespace Products.Application.Products.Queries.GetByName;

public sealed record GetByNameQuery(string Name) : IQuery<List<ProductDTO>>;
