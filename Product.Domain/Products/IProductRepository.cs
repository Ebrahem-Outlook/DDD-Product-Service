namespace Products.Domain.Products;

public interface IProductRepository
{
    // Commands.
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    void Update(Product product);
    void Delete(Product product);

    // Queries.
    Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
