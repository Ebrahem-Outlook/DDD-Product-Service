using Products.Domain.Core.BaseType;
using Products.Domain.Products.Events;
using Products.Domain.Products.ValueObjects;

namespace Products.Domain.Products;

public sealed class Product : AggregateRoot
{
    private Product() : base() { }

    public Product(Name name, Description description, Price price, Stock stock) : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Name Name { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public Price Price { get; private set; } = default!;
    public Stock Stock { get; private set; } = default!;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public static Product Create(Name name, Description description, Price price, Stock stock)
    {
        Product product = new Product(name, description, price, stock);

        product.RaiseDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public void Update(Name name, Description description, Price price, Stock stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;

        RaiseDomainEvent(new ProductUpdatedDomainEvent(this));
    }
}
