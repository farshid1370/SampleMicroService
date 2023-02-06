namespace Catalog.Infrastructure.Migrations;

public class CatalogContextDesignTimeFactory: IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();

            optionsBuilder.UseNpgsql(".", options => options.MigrationsAssembly(GetType().Assembly.GetName().Name));

            return new CatalogContext(optionsBuilder.Options,null);
        }
}