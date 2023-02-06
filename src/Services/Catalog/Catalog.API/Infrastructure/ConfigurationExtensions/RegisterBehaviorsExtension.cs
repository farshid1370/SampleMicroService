namespace Catalog.API.Infrastructure.ConfigurationExtensions;

public static class RegisterBehaviorsExtension
{
    public static IServiceCollection RegisterBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        return services;
    }
}