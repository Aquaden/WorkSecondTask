using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.CQRS.Commands.Request;
using Project.Application.CQRS.Commands.Response;
using Project.Application.CQRS.Queries.Request;
using Project.Application.CQRS.Queries.Response;

namespace WorkSecondTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest requestModel)
    {
        
        return Ok(await _mediator.Send(requestModel));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new GetByIdProductQueryRequest(id);
        return Ok(await _mediator.Send(response));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
    {
        
        return Ok(await _mediator.Send(requestModel));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = new DeleteProductCommandRequest(id);
        return Ok(response);
    }
}
