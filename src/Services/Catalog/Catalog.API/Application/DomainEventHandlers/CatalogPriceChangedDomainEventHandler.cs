using MassTransit;

namespace Catalog.Domain.DomainEvents;

public class CatalogPriceChangedDomainEventHandler:INotificationHandler<CatalogPriceChangedDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public CatalogPriceChangedDomainEventHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(CatalogPriceChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var oldPrice = notification.OldPrice;
        var newPrice = notification.NewPrice;
        var catalogId = notification.CatalogItem.Id;
        await _publishEndpoint.Publish<CatalogPriceChangedIntegrationEvent>(
            new CatalogPriceChangedIntegrationEvent(catalogId, newPrice, oldPrice), cancellationToken);
       
        
    }
}