namespace Catalog.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Create new action
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateCatalog([FromBody] CreateCatalogCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCatalog), new { id }, null);
    }
    /// <summary>
    /// Update catalog name and price
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("NameAndPrice")]
    public async Task<IActionResult> UpdateCatalogNameAndPrice([FromBody] UpdateNameAndPriceCommand command)
    {
        await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCatalog), new { id = command.Id }, null);

    }
    /// <summary>
    /// Get catalog by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCatalog(Guid id)
    {
        var catalog = await _mediator.Send(new GetCatalogQuery { CatalogId = id });
        return Ok(catalog);
    }
    /// <summary>
    /// Get catalog list with paging
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<IActionResult> GetCatalogsList(int pageNumber, int pageSize)
    {
        var listCatalog = await _mediator.Send(new GetCatalogListQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(listCatalog);
    }
    /// <summary>
    /// Update catalog stock
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("Stock")]
    public async Task<IActionResult> UpdateStock([FromBody] UpdateStockCommand command)
    {
        await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCatalog), new { id = command.Id }, null);

    }

}

