namespace Catalog.Domain.AggregatesModel.CatalogTypeAggregate;

public class CatalogType:Entity
{
    private Guid _id;
    private string _type;
    public CatalogType(Guid id, string type)
    {
        _id = id;
        _type = type;
    }
    public Guid Id => _id;
    public string Type => _type;
}