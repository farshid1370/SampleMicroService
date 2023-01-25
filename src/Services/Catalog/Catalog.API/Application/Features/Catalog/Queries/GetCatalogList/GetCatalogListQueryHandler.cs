using Catalog.Domain.AggregatesModel.CatalogAggregate;

namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalogList;

public class GetCatalogListQueryHandler:IRequestHandler<GetCatalogListQuery,CatalogListVM>
{
    private readonly ICatalogRepository _catalogRepository;
    public async Task<CatalogListVM> Handle(GetCatalogListQuery request, CancellationToken cancellationToken)
    {
        var total = await _catalogRepository.GetTotalCount();
        var catalogItems = await _catalogRepository.GetByPaging(request.PageSize,request.PageNumber);

        var result = new CatalogListVM
        {
            TotalCount = total,
            Data = new List<CatalogListItemVM>()
        };
        foreach (var catalogItem in catalogItems)
        {
            var newItem=new CatalogListItemVM
            {
                CatalogTypeId = catalogItem.CatalogTypeId,
                AvailableStock = catalogItem.AvailableStock,
                Id = catalogItem.Id,
                MaxStockThreshold = catalogItem.MaxStockThreshold,
                MinStockThreshold = catalogItem.MinStockThreshold,
                Name = catalogItem.Name,
                Price = catalogItem.Price
            };
            result.Data.ToList().Add(newItem);
        }

        return result;
    }
    
}