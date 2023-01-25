namespace Catalog.Domain.DomainEvents;

public class CatalogPriceChangedDomainEventHandler:INotificationHandler<CatalogPriceChangedDomainEvent>
{
    public Task Handle(CatalogPriceChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var oldPrice = notification.OldPrice;
        var newPrice = notification.NewPrice;
        var catalogId = notification.CatalogItem.Id;
        //TODO:Implement Integration Event
        // await _catalogIntegrationEventService.AddAndSaveEventAsync(new CatalogPriceChangedIntegrationEvent(catalogId, newPrice, oldPrice));
        return Task.CompletedTask;
    }
}