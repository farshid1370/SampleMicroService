namespace Catalog.Infrastructure;

public class CatalogContextSeed
{
    private readonly Dictionary<int, Guid> _catalogTypeIds;

    public CatalogContextSeed()
    {
        _catalogTypeIds = new Dictionary<int, Guid>
        {
            {1, Guid.NewGuid()},
            {2, Guid.NewGuid()},
            {3, Guid.NewGuid()},
            {4, Guid.NewGuid()}
        };
    }

    public async Task MigrateAndSeed(CatalogContext context)
    {

        await context.Database.MigrateAsync();


        if (!context.CatalogTypes.Any())
        {
            await context.CatalogTypes.AddRangeAsync(SeedCatalogTypes());

            await context.SaveChangesAsync();
        }
        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(SeedCatalogItems());

            await context.SaveChangesAsync();


        }
        if (!context.Suppliers.Any())
        {
            await context.Suppliers.AddRangeAsync(SeedSupplier());

            await context.SaveChangesAsync();
        }
    }
    private IEnumerable<CatalogType> SeedCatalogTypes()
    {
        return new List<CatalogType>
        {
            new (_catalogTypeIds[1],"Mug") ,
            new (_catalogTypeIds[2],"T-Shirt") ,
            new ( _catalogTypeIds[3],"Sheet") ,
            new ( _catalogTypeIds[4],"USB Memory Stick")
        };
    }
    private IEnumerable<CatalogItem> SeedCatalogItems()
    {
        return new List<CatalogItem>
        {
            new  (id:new Guid(), name: ".NET Bot Black Hoodie",price:19
                ,catalogTypeId:_catalogTypeIds[2],availableStock:100,minStockThreshold:5,maxStockThreshold:10000),
            new  (id:new Guid(),name:".NET Black & White Mug",price:12
                ,catalogTypeId:_catalogTypeIds[2],availableStock:100,minStockThreshold:5,maxStockThreshold:10000),

            new  (id:new Guid(),name: "Prism White T-Shirt",price:12
                ,catalogTypeId:_catalogTypeIds[2],availableStock:100,minStockThreshold:5,maxStockThreshold:10000),

            new  (id:new Guid(),name: ".NET Foundation T-shirt",price:19
                ,catalogTypeId:_catalogTypeIds[2],availableStock:100,minStockThreshold:5,maxStockThreshold:10000),

            new  (id : new Guid(), name: ".Roslyn Red Sheet",price:8
                ,catalogTypeId:_catalogTypeIds[2],availableStock:100,minStockThreshold:5,maxStockThreshold:10000),

            new  (id : new Guid(), name: ".NET Blue Hoodie",price:8
                ,catalogTypeId:_catalogTypeIds[2],availableStock:100,minStockThreshold:5,maxStockThreshold:10000),



        };
    }
    private IEnumerable<Supplier> SeedSupplier()
    {
        return new List<Supplier>
        {
            new (id:new Guid(),catalogTypeId:_catalogTypeIds[2],name:"supplier1",new Address("2583 Derek Drive","Akron")),
            new (id:new Guid(),catalogTypeId:_catalogTypeIds[2],name:"supplier2",new Address("771 Oak Street","Syracuse")),
        };
    }



}