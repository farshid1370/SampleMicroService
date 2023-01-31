namespace Basket.Infrastructure;

public class BasketContextSeed
{
  

    public async Task MigrateAndSeed(BasketContext context)
    {

        await context.Database.MigrateAsync();


        if (!context.CustomerBaskets.Any())
        {
            await context.CustomerBaskets.AddRangeAsync(SeedBaskets());

            await context.SaveChangesAsync();
        }
        
    }
    private IEnumerable<CustomerBasket> SeedBaskets()
    {
        return new List<CustomerBasket>
        {
           new("1"),
           new ("2")
        };
    }

}