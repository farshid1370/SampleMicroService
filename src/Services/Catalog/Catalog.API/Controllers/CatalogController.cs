using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCatalog([FromBody] CreateCatalogCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCatalog), new { id }, null);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCatalogNameAndPrice([FromBody] UpdateNameAndPriceCommand command)
    {
        await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCatalog), new { id = command.Id }, null);

    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> GetCatalog(Guid id)
    {
        var catalog = await _mediator.Send(new GetCatalogQuery { CatalogId = id });
        return Ok(catalog);
    }

    [HttpGet]
    [Route("/{pageNumber}/{pageSize}")]
    public async Task<IActionResult> GetCatalogsList(int pageNumber, int pageSize)
    {
        var listCatalog = await _mediator.Send(new GetCatalogListQuery {PageNumber = pageNumber, PageSize = pageSize});
        return Ok(listCatalog);
    }

}

