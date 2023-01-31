namespace Catalog.API.Grpc.ServerServices;

public class CatalogService : Proto.Catalog.CatalogBase
{
    private readonly IMediator _mediator;

    public CatalogService(IMediator mediator)
    {
        _mediator = mediator;
    }

   
}