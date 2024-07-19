using MediatR;

namespace Products.Application.Core.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>, IQueryBase
{

}

public interface IQueryBase
{

}
