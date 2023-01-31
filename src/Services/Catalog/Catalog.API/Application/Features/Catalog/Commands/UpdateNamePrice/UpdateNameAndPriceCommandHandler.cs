using Catalog.API.Exceptions;
using Catalog.Domain.AggregatesModel.CatalogAggregate;

namespace Catalog.API.Application.Features.Catalog.Commands.UpdateNamePrice;

public class UpdateNameAndPriceCommandHandler:IRequestHandler<UpdateNameAndPriceCommand>
{
    private readonly ICatalogRepository _catalogRepository;

    public UpdateNameAndPriceCommandHandler(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<Unit> Handle(UpdateNameAndPriceCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogRepository.GetById(request.Id);

        if (catalogItem == null)
        {
            throw new NotFoundException(nameof(catalogItem), request.Id);
        }

        catalogItem.UpdateName(request.Name);
        catalogItem.UpdatePrice(request.Price);



        await _catalogRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return Unit.Value;
    }
}