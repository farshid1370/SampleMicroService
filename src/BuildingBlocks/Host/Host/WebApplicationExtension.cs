using Microsoft.AspNetCore.Builder;
using static System.Net.Mime.MediaTypeNames;

namespace Host
{
    public static class WebApplicationExtension
    {

        public static WebApplication MigrateDataBase<TContext>(this WebApplication app,  Action<IServiceProvider> migrateAndSeed)
        {
            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;

            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1),
                retryCount: 5);
            var retry = Policy.Handle<Exception>().WaitAndRetry(delay);
            retry.Execute(() => { migrateAndSeed(service); });
            return app;
        }

    }
}