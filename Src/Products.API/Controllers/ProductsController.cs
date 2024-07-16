using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.API.Contracts;
using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Products.Commands.DeleteProduct;
using Products.Application.Products.Commands.UpdateProduct;
using Products.Application.Products.Queries.GetAll;
using Products.Application.Products.Queries.GetById;
using Products.Application.Products.Queries.GetByName;

namespace Products.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public sealed class ProductsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
        => Ok(await sender.Send(
            new CreateProductCommand(
                request.Name, 
                request.Description, 
                request.Price, 
                request.Stock)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductRequest request)
        => Ok(await sender.Send(
            new UpdateProductCommand(
                request.Id,
                request.Name,
                request.Description,
                request.Price,
                request.Stock)));

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductRequest request)
        => Ok(await sender.Send(
            new DeleteProductCommand(
                request.ProductId)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllProductsQuery()));

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await sender.Send(new GetByIdProductQuery(id)));

    [HttpPost("name")]
    public async Task<IActionResult> GetByName(string name) => Ok(await sender.Send(new GetByNameQuery(name)));
}
