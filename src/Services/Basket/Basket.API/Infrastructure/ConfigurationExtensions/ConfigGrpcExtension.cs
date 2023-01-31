namespace Basket.API.Infrastructure.ConfigurationExtensions;

public static class ConfigGrpcExtension
{
    public static IServiceCollection RegisterGrpcService(this IServiceCollection services)
    {

        services.AddGrpc(options =>
        {
            options.EnableDetailedErrors = true;

        });
       
        return services;
    }
    public static IEndpointRouteBuilder GrpcConfig(this IEndpointRouteBuilder app)
    {

      
      
        return app;

    }
}