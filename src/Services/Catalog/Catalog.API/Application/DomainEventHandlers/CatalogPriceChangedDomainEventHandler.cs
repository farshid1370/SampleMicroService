namespace Catalog.Domain.DomainEvents;

public class CatalogPriceChangedDomainEventHandler:INotificationHandler<CatalogPriceChangedDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICatalogIntegrationEventService _catalogIntegrationEventService;

    public CatalogPriceChangedDomainEventHandler(//IPublishEndpoint publishEndpoint, 
        ICatalogIntegrationEventService catalogIntegrationEventService)
    {
        //_publishEndpoint = publishEndpoint;
        _catalogIntegrationEventService = catalogIntegrationEventService;
    }

    public async Task Handle(CatalogPriceChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var oldPrice = notification.OldPrice;
        var newPrice = notification.NewPrice;
        var catalogId = notification.CatalogItem.Id;
        await _catalogIntegrationEventService.AddAndSaveEventAsync(new CatalogPriceChangedIntegrationEvent(catalogId, newPrice, oldPrice));
        //await _publishEndpoint.Publish<CatalogPriceChangedIntegrationEvent>(
        //    new CatalogPriceChangedIntegrationEvent(catalogId, newPrice, oldPrice), cancellationToken);


    }
}