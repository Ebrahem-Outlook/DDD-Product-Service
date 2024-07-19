using MediatR;

namespace Products.Application.Core.Abstractions.Messaging;

public interface ICommand : IRequest
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>
    where TResponse : class
{

}