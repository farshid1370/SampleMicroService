namespace Basket.Infrastructure.Infrastructure.ConfigurationExtensions;

public static class BasketContextSeedExtension
{


    public static async Task BasketMigrateAndSeed(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider
            .GetRequiredService<BasketContext>();

        await context.Database.MigrateAsync();


        if (!context.CustomerBaskets.Any())
        {
            await context.CustomerBaskets.AddRangeAsync(SeedBaskets());

            await context.SaveChangesAsync();
        }

    }
    private static IEnumerable<CustomerBasket> SeedBaskets()
    {
        return new List<CustomerBasket>
        {
           new("1"),
           new ("2")
        };
    }

}