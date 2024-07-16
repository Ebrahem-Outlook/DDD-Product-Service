using MediatR;
using Microsoft.Extensions.Logging;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Core.Behaviors;

internal class ExceptionHandlingBehavior<TRequest, TResponse>(
    ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch(Exception)
        {
            logger.LogError("Unhandle Exception  for {RequestName}", typeof(TRequest).Name);

            throw;
        }
    }
}
