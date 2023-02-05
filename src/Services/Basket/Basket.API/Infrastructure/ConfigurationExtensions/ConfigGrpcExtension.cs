using Basket.API.Grpc.ClientServices;

namespace Basket.API.Infrastructure.ConfigurationExtensions;

public static class ConfigGrpcExtension
{
    public static IServiceCollection RegisterGrpcService(this IServiceCollection services)
    {
        services.AddScoped<ICatalogService, CatalogService>();
       

        services.AddGrpcClient<Catalog.API.Grpc.Proto.Catalog.CatalogClient>((services, options) =>
        {
            options.Address = new Uri("");
        });
        return services;
    }
    public static IEndpointRouteBuilder GrpcConfig(this IEndpointRouteBuilder app)
    {

      
      
        return app;

    }
}