

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get supplier by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplier(Guid id)
    {
        var supplier = await _mediator.Send(new GetSupplierQuery() { SupplierId = id });
        return Ok(supplier);
    }
}