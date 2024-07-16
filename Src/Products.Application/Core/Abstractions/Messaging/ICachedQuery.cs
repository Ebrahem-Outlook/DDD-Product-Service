using System.Security;

namespace Products.Application.Core.Abstractions.Messaging;

public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }

    TimeSpan? Expiration {get;}
}
