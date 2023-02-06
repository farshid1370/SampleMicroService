namespace Catalog.API.Application.Integration;

public class CatalogIntegrationEventService:ICatalogIntegrationEventService
{
    private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly CatalogContext _catalogContext;
    private readonly IIntegrationEventLogService _eventLogService;

    public CatalogIntegrationEventService(Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory, IPublishEndpoint publishEndpoint, CatalogContext catalogContext)
    {
        _integrationEventLogServiceFactory = integrationEventLogServiceFactory;
        _publishEndpoint = publishEndpoint;
        _catalogContext = catalogContext;
        _eventLogService = _integrationEventLogServiceFactory(_catalogContext.Database.GetDbConnection());
    }
    public async Task PublishEventsThroughEventBusAsync(Guid transactionId)
    {
        var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);
        foreach (var logEvt in pendingLogEvents)
        {
            try
            {
                await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                await _publishEndpoint.Publish(logEvt.IntegrationEvent, logEvt.IntegrationEvent.GetType());
                await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
            }
            catch (Exception ex)
            {

                await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
            }
        }
    }

    public async Task AddAndSaveEventAsync(IIntegrationMessage evt)
    {
        await _eventLogService.SaveEventAsync(evt, _catalogContext.GetCurrentTransaction());
    }

    public async Task PublishUnSendedEventsThroughEventBusAsync()
    {
        var pendingLogEvents = await _eventLogService.RetrieveEventLogsPublishedFailedToPublishAsync(5);

        foreach (var logEvt in pendingLogEvents)
        {

            try
            {
                await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                await _publishEndpoint.Publish(logEvt.IntegrationEvent, logEvt.IntegrationEvent.GetType());
                await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
            }
            catch (Exception ex)
            {
                await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
            }
        }
    }
}