namespace Basket.Infrastructure.Infrastructure.ConfigurationExtensions;

public static class ConfigDatabaseExtension
{
    public static IServiceCollection AddBasketDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BasketContext>(options =>
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