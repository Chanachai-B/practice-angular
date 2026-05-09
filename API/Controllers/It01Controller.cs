using Application.IT01;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class It01Controller(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] List.Request request, CancellationToken ct)
        => Ok(await mediator.Send(request, ct));

    [HttpGet("user")]
    public async Task<IActionResult> GetById([FromQuery] Detail.Request request, CancellationToken ct)
    {
        var result = await mediator.Send(request, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Create.Request request, CancellationToken ct)
    {
        var id = await mediator.Send(request, ct);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}