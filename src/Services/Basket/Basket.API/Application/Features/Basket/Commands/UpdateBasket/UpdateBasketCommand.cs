namespace Basket.API.Application.Features.Basket.Commands.UpdateBasket;

public class UpdateBasketCommand:IRequest<Unit>
{
    public string BuyerId { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
}