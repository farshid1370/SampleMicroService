
namespace Catalog.Infrastructure.Infrastructure.ConfigurationExtensions;

public static class RegisterInfrastructureServicesExtension
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ICatalogRepository, CatalogRepository>();
        return services;
    }
}