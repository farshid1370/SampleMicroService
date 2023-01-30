using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Infrastructure;

public class CatalogContext:DbContext,IUnitOfWork
{
    private readonly IMediator _mediator;

    public CatalogContext(DbContextOptions<CatalogContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    public DbSet<CatalogItem> CatalogItems { get; set; }

    public DbSet<CatalogType> CatalogTypes { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _mediator.DispatchDomainEventsAsync(this);
        await SaveChangesAsync(cancellationToken);
        return true;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogEntityConfiguration());
        builder.ApplyConfiguration(new CatalogTypeEntityConfiguration());
        builder.ApplyConfiguration(new SupplierEntityConfiguration());
        builder.ApplyConfiguration(new SupplierItemEntityConfiguration());

    }
    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseNpgsql("");

            return new CatalogContext(optionsBuilder.Options,null);
        }
    }
}