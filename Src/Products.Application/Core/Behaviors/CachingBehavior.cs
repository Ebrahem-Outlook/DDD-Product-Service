using MediatR;
using Products.Application.Core.Abstractions.Messaging;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Core.Behaviors;

internal sealed class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQueryBase
    where TResponse : Result
{
    

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
