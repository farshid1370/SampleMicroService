namespace Catalog.API.Application.Integration;

public interface ICatalogIntegrationEventService
{
    Task PublishEventsThroughEventBusAsync(Guid transactionId);
    Task AddAndSaveEventAsync(IIntegrationMessage evt);
    Task PublishUnSendedEventsThroughEventBusAsync();
}