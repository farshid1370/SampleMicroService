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
        var basket = new CustomerBasket(request.BuyerId);
        foreach (var item in request.BasketItems)
        {
            basket.AddBasketItem(item.Id, item.Quantity, item.ProductId, item.ProductName, item.UnitPrice,
                item.OldUnitPrice);
        }

        _repository.UpdateBasket(basket);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return Unit.Value;
    }
}