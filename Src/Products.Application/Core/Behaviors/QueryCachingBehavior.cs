using MediatR;
using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Core.Behaviors;

internal sealed class QueryCachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
    where TResponse : Result
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
