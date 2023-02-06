namespace Catalog.API.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>

{
    private readonly CatalogContext _dbContext;
    private readonly ICatalogIntegrationEventService _catalogIntegrationEventService;

    public TransactionBehavior(CatalogContext dbContext, ICatalogIntegrationEventService catalogIntegrationEventService)
    {
        _dbContext = dbContext;
        _catalogIntegrationEventService = catalogIntegrationEventService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = default(TResponse);

        if (_dbContext.HasActiveTransaction)
        {
            return await next();
        }

        var strategy = _dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {

            Guid transactionId;

            await using var transaction = await _dbContext.BeginTransactionAsync();

            response = await next();

            await _dbContext.CommitTransactionAsync(transaction);

            transactionId = transaction.TransactionId;

            await _catalogIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);

        });

        return response;
    }
}