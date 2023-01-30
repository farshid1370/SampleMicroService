using Catalog.Infrastructure.Repositories;

namespace Catalog.API.Infrastructure.ConfigurationExtensions;

public static class ConfigSwaggerExtension
{
   
        public static IServiceCollection RegisterSwaggerService(this IServiceCollection services)
        {

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
        }
        public static IApplicationBuilder SwaggerConfig(this IApplicationBuilder app)
        {

        app.UseSwagger();
        app.UseSwaggerUI();
        return app;

        }

}