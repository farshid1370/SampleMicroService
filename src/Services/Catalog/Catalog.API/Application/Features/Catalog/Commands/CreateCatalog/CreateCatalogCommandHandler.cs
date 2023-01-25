namespace Catalog.API.Application.Features.Catalog.Commands.CreateCatalog;

public class CreateCatalogCommandHandler:IRequestHandler<CreateCatalogCommand,Guid>
{
    private readonly ICatalogRepository _catalogRepository;

    public CreateCatalogCommandHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<Guid> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = new CatalogItem(request.Name, request.Price, request.CatalogTypeId, request.AvailableStock,
            request.MinStockThreshold, request.MaxStockThreshold);
        await _catalogRepository.Add(catalogItem);
        await _catalogRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return catalogItem.Id;
    }
}