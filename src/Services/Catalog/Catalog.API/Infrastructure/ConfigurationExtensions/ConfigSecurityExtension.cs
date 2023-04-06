using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Common;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.API.Infrastructure.ConfigurationExtensions
{
    public static class ConfigKeycloakExtension
    {
        public static IServiceCollection RegisterKeyCloak(this IServiceCollection services,CatalogSetting options)
        {

            var authenticationOptions = new KeycloakAuthenticationOptions
            {
                AuthServerUrl = options.KeyCloakSettingsRoot.AuthServerUrl??"",
                VerifyTokenAudience = options.KeyCloakSettingsRoot.VerifyTokenAudience,
                SslRequired = options.KeyCloakSettingsRoot.SslRequired??"",
                Realm = options.KeyCloakSettingsRoot.Realm ?? "",
                Resource = options.KeyCloakSettingsRoot.Resource ?? "",
                Credentials = new KeycloakClientInstallationCredentials
                {
                    Secret = options.KeyCloakSettingsRoot.CredentialsSettings.Secret??""
                },
            };

            services.AddKeycloakAuthentication(authenticationOptions, o =>

            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
        
                    ValidateAudience = authenticationOptions.VerifyTokenAudience?? false,
        
                };
            });
            services.AddAuthorization();

       
            return services;
        }
    }
}
