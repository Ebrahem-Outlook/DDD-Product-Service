namespace Products.Application.Products.Queries.GetAll;

public sealed record ProductDTO(
    string Name, 
    string Description,
    decimal Price,
    int Stock);
