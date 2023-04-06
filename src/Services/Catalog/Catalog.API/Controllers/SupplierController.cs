

using Catalog.API.Application.Features.Catalog.Queries.GetSuppliersList;
using Microsoft.AspNetCore.Authorization;

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


    /// <summary>
    /// Get supplier list with paging
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<IActionResult> GetSuppliersList(int pageNumber, int pageSize)
    {
        var supplierList = await _mediator.Send(new GetSuppliersListQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(supplierList);
    }
}