using Catalog.API.Infrastructure.Filters;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Infrastructure.ConfigurationExtensions;

public static class ConfigSwaggerExtension
{

    public static IServiceCollection RegisterSwaggerService(this IServiceCollection services)
    {
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.Api", Version = "v1" });
            c.OperationFilter<AuthorizeCheckOperationFilter>();
            c.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.OAuth2,

                Flows = new OpenApiOAuthFlows()
                {
                    Password = new OpenApiOAuthFlow()
                    {
                        Scopes = new Dictionary<string, string>()
                        {
                            {"email", ""},
                            {"offline_access", ""},
                            {"openid", ""},
                            {"profile", ""},
                        },
                        TokenUrl = new Uri($"http://localhost:8080/realms/hcm-dev/protocol/openid-connect/token"),//{{server}}/realms/{{realm}}/protocol/openid-connect/token
                        RefreshUrl = new Uri($"http://localhost:8080/realms/hcm-dev/protocol/openid-connect/token")
                    }
                },

                Description = "Get Token from Token endpoint and use it in <code>bearer</code> header"
            });

            var filePath = Path.Combine(AppContext.BaseDirectory,
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            if (File.Exists(filePath))
                c.IncludeXmlComments(filePath);
        });

        return services;
    }

    public static IApplicationBuilder SwaggerConfig(this WebApplication app,CatalogSetting options)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Microservice");
            c.RoutePrefix = "swagger";
            c.OAuthClientId(options.KeyCloakSettingsRoot.Resource);
            c.OAuthClientSecret(options.KeyCloakSettingsRoot.CredentialsSettings.Secret??"");
            c.OAuthAppName("Catalog Api");
            c.OAuthUsePkce();
            c.ConfigObject.DefaultModelRendering = Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model;
        });
        
        return app;

    }

}