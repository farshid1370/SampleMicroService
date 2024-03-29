﻿namespace Basket.API.Application.Features.Basket.Commands.UpdateBasketCatalogPrice;

public class UpdateBasketCatalogPriceCommandHandler : IRequestHandler<UpdateBasketCatalogPriceCommand,Unit>
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

            _repository.UpdateBasket(basket);
            UpdatePriceInBasketItems(request.CatalogId, request.NewPrice, request.OldPrice, basket);
        }

        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return Unit.Value;

    }
    private void UpdatePriceInBasketItems(Guid productId, decimal newPrice, decimal oldPrice, CustomerBasket basket)
    {
        var itemsToUpdate = basket?.BasketItems?.Where(x => x.ProductId == productId).ToList();

        if (itemsToUpdate == null || itemsToUpdate.Count == 0) return;

        foreach (var item in itemsToUpdate.Where(item => item.UnitPrice != newPrice))
        {
            item.SetNewPrice(newPrice);
        }

        _repository.UpdateBasket(basket);


    }
}