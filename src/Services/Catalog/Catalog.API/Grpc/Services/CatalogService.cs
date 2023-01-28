namespace Catalog.API.Grpc.Services;

public class CatalogService : Proto.Catalog.CatalogBase
{
    private readonly IMediator _mediator;

    public CatalogService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<CreateCatalogResponse> CreateCatalog(CreateCatalogRequest request, ServerCallContext context)
    {
        var command = new CreateCatalogCommand
        {
            Name = request.Name,
            Price = request.Price,
            AvailableStock = request.AvailableStock,
            MinStockThreshold = request.MinStockThreshold,
            MaxStockThreshold = request.MaxStockThreshold,
            CatalogTypeId = new Guid(request.CatalogTypeId)
        };
        var id = await _mediator.Send(command);
        return new CreateCatalogResponse { Id = id.ToString() };
    }

    public override async Task<UpdateCatalogNameAndPriceResponse> UpdateCatalogNameAndPrice(UpdateCatalogNameAndPriceRequest request, ServerCallContext context)
    {
        var command = new UpdateNameAndPriceCommand
        {
            Id = new Guid(request.Id),
            Price = request.Price,
            Name = request.Name
        };
        await _mediator.Send(command);
        return new UpdateCatalogNameAndPriceResponse();
    }

    public override async Task<CatalogItemResponse> GetCatalog(CatalogItemRequest request, ServerCallContext context)
    {
        var command = new GetCatalogQuery { CatalogId = new Guid(request.Id) };
        var catalog = await _mediator.Send(command);
        return new CatalogItemResponse
        {
            Id = catalog.Id.ToString(),
            Name = catalog.Name,
            Price = catalog.Price,
            AvailableStock = catalog.AvailableStock,
            MinStockThreshold = catalog.MinStockThreshold,
            MaxStockThreshold = catalog.MaxStockThreshold

        };

    }

    public override async Task<PagingCatalogItemsResponse> GetCatalogItems(CatalogItemsRequest request, ServerCallContext context)
    {
        var command = new GetCatalogListQuery { PageNumber = request.PageNumber, PageSize = request.PageSize };
        var catalogList = await _mediator.Send(command);
        var response = new PagingCatalogItemsResponse
        {
            TotalCount = catalogList.TotalCount
          
        };
        foreach (var catalog in catalogList.Data)
        {
            response.Data.Add(new CatalogItemResponse
            {
                Id = catalog.Id.ToString(),
                Name = catalog.Name,
                Price = catalog.Price,
                AvailableStock = catalog.AvailableStock,
                MinStockThreshold = catalog.MinStockThreshold,
                MaxStockThreshold = catalog.MaxStockThreshold
            });
        }
        return response;

    }
}