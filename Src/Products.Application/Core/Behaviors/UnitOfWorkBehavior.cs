using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Products.Application.Core.Abstractions.Data;
using Products.Application.Core.Abstractions.Messaging;

namespace Products.Application.Core.Behaviors;

internal sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IQueryBase)
        {
            return await next();
        }

        await _unitOfWork.BeginTransaction(cancellationToken);
        
        TResponse response = await next();

        if (response is )

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }
}
