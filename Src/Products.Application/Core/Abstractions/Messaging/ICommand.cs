using MediatR;

namespace Products.Application.Core.Abstractions.Messaging;

public interface ICommand : IRequest, ICommandBase
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>, ICommandBase
    where TResponse : class
{

}

public interface ICommandBase
{

}
