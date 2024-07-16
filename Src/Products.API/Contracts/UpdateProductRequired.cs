namespace Products.API.Contracts;

public sealed record UpdateProductRequired(
    Guid Id, 
    string Name, 
    string Description, 
    decimal Price,
    int Stock);
