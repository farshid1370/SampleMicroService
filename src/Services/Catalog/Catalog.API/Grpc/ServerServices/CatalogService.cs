namespace Catalog.API.Grpc.ServerServices;

public class CatalogService : Proto.Catalog.CatalogBase
{
    private readonly IMediator _mediator;

    public CatalogService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<CatalogPriceResponse> GetCatalogPrice(CatalogPriceRequest request, ServerCallContext context)
    {
        var catalog= await _mediator.Send(new GetCatalogQuery {CatalogId = new Guid(request.CatalogId)});
        return new CatalogPriceResponse {Price = catalog.Price};
    }
}