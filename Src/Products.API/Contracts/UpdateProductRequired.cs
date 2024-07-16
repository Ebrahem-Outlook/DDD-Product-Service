namespace Products.API.Contracts;

public sealed record UpdateProductRequest(
    Guid Id, 
    string Name, 
    string Description, 
    decimal Price,
    int Stock);
