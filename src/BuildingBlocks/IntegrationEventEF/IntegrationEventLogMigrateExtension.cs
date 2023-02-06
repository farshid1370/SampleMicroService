

namespace Catalog.Infrastructure.Infrastructure.ConfigurationExtensions;

public static class IntegrationEventLogMigrateExtension
{
   
    public static async Task IntegrationEventLogMigrate(this IHost app)
    {

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider
            .GetRequiredService<IntegrationEventLogContext>();

        await context.Database.MigrateAsync();
        
    }

}