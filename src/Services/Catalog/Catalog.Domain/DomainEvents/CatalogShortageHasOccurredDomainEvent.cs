namespace Catalog.Domain.DomainEvents;

public class CatalogShortageHasOccurredDomainEvent:INotification
{
    public int RequiredInventory { get; private set; }

    public CatalogItem CatalogItem { get; private set; }

    public DateTime LowOfStockDateTime { get; private set; }
    public CatalogShortageHasOccurredDomainEvent(int requiredInventory, CatalogItem catalogItem)
    {
        RequiredInventory = requiredInventory;
        CatalogItem = catalogItem;
        LowOfStockDateTime = DateTime.Now;
    }
}