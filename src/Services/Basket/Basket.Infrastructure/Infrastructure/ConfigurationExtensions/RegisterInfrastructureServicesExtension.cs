
namespace Basket.Infrastructure.Infrastructure.ConfigurationExtensions;

public static class RegisterInfrastructureServicesExtension
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        
        services.AddScoped<IBasketRepository, BasketRepository>();
        
        return services;
    }
}