namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalogList;

public class CatalogListVM
{
    public long TotalCount { get; set; }

    public IEnumerable<CatalogListItemVM> Data { get; set; }
}

public class CatalogListItemVM
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Guid CatalogTypeId { get; set; }

    public int AvailableStock { get; set; }

    public int MinStockThreshold { get; set; }

    public int MaxStockThreshold { get; set; }
}