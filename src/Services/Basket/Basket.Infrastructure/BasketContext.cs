using Basket.Domain.SeedWork;
using Basket.Infrastructure.EntityConfiguration;
using Basket.Infrastructure.Infrastructure.Extensions;
using MediatR;

namespace Basket.Infrastructure;

public class BasketContext:DbContext,IUnitOfWork
{
    private readonly IMediator _mediator;

    public BasketContext(DbContextOptions<BasketContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    public DbSet<CustomerBasket> CustomerBaskets { get; set; }

    public DbSet<BasketItem> BasketItems { get; set; }

   

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _mediator.DispatchDomainEventsAsync(this);
        await SaveChangesAsync(cancellationToken);
        return true;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerBasketEntityConfiguration());
        builder.ApplyConfiguration(new BasketItemEntityConfiguration());
       

    }
    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<BasketContext>
    {
        public BasketContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BasketContext>()
                .UseNpgsql("");

            return new BasketContext(optionsBuilder.Options,null);
        }
    }
}