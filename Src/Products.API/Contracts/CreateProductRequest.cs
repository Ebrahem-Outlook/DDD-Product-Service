namespace Products.API.Contracts;

public sealed record CreateProductRequest(
    string Name, 
    string Description, 
    decimal Price, 
    int Stock);
