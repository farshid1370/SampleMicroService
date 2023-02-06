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
   
    private IDbContextTransaction _currentTransaction;
    public bool HasActiveTransaction => _currentTransaction != null;

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            transaction.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

}