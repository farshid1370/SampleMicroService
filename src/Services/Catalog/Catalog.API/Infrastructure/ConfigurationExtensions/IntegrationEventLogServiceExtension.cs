namespace Catalog.API.Infrastructure.ConfigurationExtensions;

public static class IntegrationEventLogServiceExtension
{
    public static IServiceCollection AddIntegrationEventLogService(this IServiceCollection services)
    {
        services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
            sp => c => new IntegrationEventLogServicePostgre(c));

        services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();

        return services;
    }
}