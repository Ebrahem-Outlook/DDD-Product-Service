using Microsoft.Extensions.Caching.Memory;
using Products.Domain.Products;
using Products.Infrastructure.Repositories;

namespace Products.Infrastructure.Caching;

internal sealed class CachedProductRepository(ProductRepository decorated, IMemoryCache memoryCache) : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await decorated.AddAsync(product, cancellationToken);
        string key = $"Key-{product.Id}";
        memoryCache.Remove(key);
    }

    public void Update(Product product)
    {
        decorated.Update(product);
        string key = $"Key-{product.Id}";
        memoryCache.Remove(key);
    }

    public void Delete(Product product)
    {
        decorated.Delete(product);
        string key = $"Key-{product.Id}";
        memoryCache.Remove(key);
    }

    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        string key = "Key-AllProducts";
        return await memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            return decorated.GetAllAsync(cancellationToken);
        });
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"Key-{id}";
        return await memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            return decorated.GetByIdAsync(id, cancellationToken);
        });
    }

    public async Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        string key = $"Key-Name";
        return await memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            return decorated.GetByNameAsync(name, cancellationToken);
        });
    }
}
