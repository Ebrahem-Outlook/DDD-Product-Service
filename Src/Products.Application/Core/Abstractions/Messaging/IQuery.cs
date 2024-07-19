using MediatR;
using Products.Domain.Core.BaseType.Result;

namespace Products.Application.Core.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : Result
{

}
