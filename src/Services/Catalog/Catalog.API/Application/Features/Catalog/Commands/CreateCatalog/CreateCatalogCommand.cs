namespace Catalog.API.Application.Features.Catalog.Commands.CreateCatalog;

public class CreateCatalogCommand:IRequest<Guid>
{
    public string Name { get;  set; }
    public int Price { get;  set; }
    public Guid CatalogTypeId { get;  set; }
    public int AvailableStock { get;  set; }
    public int MinStockThreshold { get;  set; }
    public int MaxStockThreshold { get;  set; }
}