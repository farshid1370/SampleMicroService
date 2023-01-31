namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalogList;

public class GetCatalogListQueryHandler : IRequestHandler<GetCatalogListQuery, CatalogListVM>
{
    private readonly ICatalogRepository _catalogRepository;

    public GetCatalogListQueryHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<CatalogListVM> Handle(GetCatalogListQuery request, CancellationToken cancellationToken)
    {
        var total = await _catalogRepository.GetTotalCount();
        var catalogItems = await _catalogRepository.GetByPaging(request.PageSize, request.PageNumber);

        var result = new CatalogListVM
        {
            TotalCount = total

        };
        var list = catalogItems.Select(catalogItem => new CatalogListItemVM
        {
            CatalogTypeId = catalogItem.CatalogTypeId,
            AvailableStock = catalogItem.AvailableStock,
            Id = catalogItem.Id,
            MaxStockThreshold = catalogItem.MaxStockThreshold,
            MinStockThreshold = catalogItem.MinStockThreshold,
            Name = catalogItem.Name,
            Price = catalogItem.Price
        })
            .ToList();
        result.Data = list;

        return result;
    }

}