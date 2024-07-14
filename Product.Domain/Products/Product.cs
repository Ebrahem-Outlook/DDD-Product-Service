using Product.Domain.Core.BaseType;

namespace Product.Domain.Products;

public sealed class Product : AggregateRoot
{
    private Product() : base() { }

    private Product(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public static Product Create(string name, string description, decimal price, int stock)
    {
        Product product = new Product(name, description, price, stock);

        return product;
    }

    public void Update(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;

        
    }
}
