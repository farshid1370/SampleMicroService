namespace Catalog.Domain.AggregatesModel.CatalogTypeAggregate;

public class CatalogType:Entity
{
    public CatalogType(string type)
    {
        Type = type;
    }

    public string Type { get;private set; }
}