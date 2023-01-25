namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalog;

public class CatalogVM
{
    public Guid Id { get; set; }
    public string Name { get; set; }
   
    public decimal Price { get; set; }

    public Guid CatalogTypeId { get; set; }

    public int AvailableStock { get; set; }

    public int MinStockThreshold { get; set; }

    public int MaxStockThreshold { get; set; }
}