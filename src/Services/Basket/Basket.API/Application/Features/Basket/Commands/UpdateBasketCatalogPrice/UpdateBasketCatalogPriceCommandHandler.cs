namespace Basket.API.Application.Features.Basket.Commands.UpdateBasketCatalogPrice;

public class UpdateBasketCatalogPriceCommandHandler : IRequestHandler<UpdateBasketCatalogPriceCommand>
{
    private readonly IBasketRepository _repository;

    public UpdateBasketCatalogPriceCommandHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateBasketCatalogPriceCommand request, CancellationToken cancellationToken)
    {
        var userIds = await _repository.GetUsers();
        foreach (var id in userIds)
        {
            var basket = await _repository.GetBasket(id);

            UpdatePriceInBasketItems(request.CatalogId, request.NewPrice, request.OldPrice, basket);
        }

        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return Unit.Value;

    }
    private void UpdatePriceInBasketItems(Guid productId, decimal newPrice, decimal oldPrice, CustomerBasket basket)
    {
        var itemsToUpdate = basket?.Items?.Where(x => x.ProductId == productId).ToList();

        if (itemsToUpdate == null) return;

        foreach (var item in itemsToUpdate.Where(item => item.UnitPrice == oldPrice))
        {
            item.SetNewPrice(newPrice);
        }

        _repository.UpdateBasket(basket);


    }
}