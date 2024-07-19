using MediatR;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Core.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : Result<TResponse>
{

}
