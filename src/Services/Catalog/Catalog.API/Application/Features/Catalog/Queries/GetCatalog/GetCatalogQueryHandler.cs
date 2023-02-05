namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalog;

public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, CatalogVM>
{
    private readonly ICatalogRepository _catalogRepository;

    public GetCatalogQueryHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<CatalogVM> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
    {
        var item = await _catalogRepository.GetById(request.CatalogId);
        if (item != null)
            // mapping ... u can use auto mapper or mapster
            return new CatalogVM
            {
                AvailableStock = item.AvailableStock,
                CatalogTypeId = item.CatalogTypeId,
                MaxStockThreshold = item.MaxStockThreshold,
                Name = item.Name,
                Price = item.Price,
                MinStockThreshold = item.MinStockThreshold,
                Id = item.Id
            };

        return null;
    }
}