using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.API.Contracts;
using Products.Application.Products.Commands.CreateProduct;

namespace Products.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public sealed class ProductsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateProductRequest request)
        => Ok(await sender.Send(CreateProductCommand()));
}
