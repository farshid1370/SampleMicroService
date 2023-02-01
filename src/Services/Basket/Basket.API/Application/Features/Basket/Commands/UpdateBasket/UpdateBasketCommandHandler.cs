namespace Basket.API.Application.Features.Basket.Commands.UpdateBasket;

public class UpdateBasketCommandHandler:IRequestHandler<UpdateBasketCommand>
{
    private readonly IBasketRepository _repository;

    public UpdateBasketCommandHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await _repository.GetBasket(request.BuyerId);
        foreach (var item in request.BasketItems)
        {
            basket.AddBasketItem( item.Quantity, item.ProductId, item.ProductName, item.UnitPrice,
                item.OldUnitPrice);
        }

        _repository.AddBasketItems(basket.Items);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return Unit.Value;
    }
}