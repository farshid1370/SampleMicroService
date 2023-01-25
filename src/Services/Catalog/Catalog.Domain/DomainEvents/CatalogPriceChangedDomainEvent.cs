namespace Catalog.Domain.DomainEvents;

public class CatalogPriceChangedDomainEvent:INotification
{
    public decimal NewPrice { get; private set; }
    public decimal OldPrice { get; private set; }

    public CatalogItem CatalogItem { get; private set; }

    public CatalogPriceChangedDomainEvent(decimal newPrice, decimal oldPrice, CatalogItem catalogItem)
    {
        NewPrice = newPrice;
        OldPrice = oldPrice;
        CatalogItem = catalogItem;
    }
}