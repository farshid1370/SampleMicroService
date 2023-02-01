namespace Catalog.API.Infrastructure.ConfigurationExtensions;

public static class ConfigMasstransitExtension
{
    public static IServiceCollection RegisterMasstransitService(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetExecutingAssembly());
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Publish<IntegrationEvent>(p =>
                {
                    p.Exclude = true;

                });

                cfg.Publish<IntegrationMessage>(p =>
                {
                    p.Exclude = true;
                });
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }

}