
namespace Catalog.API.Application.Features.Catalog.Commands.UpdateStock;

public class UpdateStockCommandHandler:IRequestHandler<UpdateStockCommand,int>
{
    private readonly ICatalogRepository _catalogRepository;

    public UpdateStockCommandHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<int> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogRepository.GetById(request.Id);

        if (catalogItem == null)
        {
            throw new NotFoundException(nameof(CatalogItem), request.Id);
        }

        var removed = catalogItem.RemoveStock(request.Quantity);

        await _catalogRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return removed;
    }
}