namespace Catalog.Infrastructure.Infrastructure.ConfigurationExtensions;

public static class ConfigIntegrationEventLogDatabaseExtension
{
    public static IServiceCollection AddIntegrationEventLogDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IntegrationEventLogContext>(options =>
        {
            options.UseNpgsql(configuration["ConnectionString"],
                npgsqlOptionsAction: builder =>
                {
                    builder.MigrationsAssembly(typeof(ConfigDatabaseExtension).Assembly.GetName().Name);
                    builder.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });
        });

        return services;
    }
}