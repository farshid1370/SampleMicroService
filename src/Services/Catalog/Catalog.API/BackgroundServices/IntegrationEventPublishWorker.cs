namespace Catalog.API.BackgroundServices;

public class IntegrationEventPublishWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public IntegrationEventPublishWorker(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var _catalogIntegrationEventService = scope.ServiceProvider.GetRequiredService<ICatalogIntegrationEventService>();
        var _options = scope.ServiceProvider.GetRequiredService<IOptions<CatalogSetting>>();

        while (!stoppingToken.IsCancellationRequested)
        {

            await _catalogIntegrationEventService.PublishUnSendedEventsThroughEventBusAsync();

            await Task.Delay(_options.Value.CheckUpdateTimeForEventPublinshWorker, stoppingToken);

        }

    }
}