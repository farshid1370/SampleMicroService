namespace Basket.API.Infrastructure.ConfigurationExtensions;

public static class ConfigGrpcExtension
{
    public static IServiceCollection RegisterGrpcService(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<ICatalogService, CatalogService>();
       

        services.AddGrpcClient<Catalog.API.Grpc.Proto.Catalog.CatalogClient>((services, options) =>
        {
            options.Address = new Uri(configuration["CatalogGrpcUrl"]);
        });
        return services;
    }
    
}