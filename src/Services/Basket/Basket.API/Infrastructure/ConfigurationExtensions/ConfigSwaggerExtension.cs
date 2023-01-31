namespace Basket.API.Infrastructure.ConfigurationExtensions;

public static class ConfigSwaggerExtension
{

    public static IServiceCollection RegisterSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {

            var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            if (File.Exists(filePath))
            {
                c.IncludeXmlComments(filePath);
            }
        }

            );
        return services;
    }
    public static IApplicationBuilder SwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;

    }

}