using MediatR;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Core.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>
    where TResponse : Result<TResponse>
{

}
