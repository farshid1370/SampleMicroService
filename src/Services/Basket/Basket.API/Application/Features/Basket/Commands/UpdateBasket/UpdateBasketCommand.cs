namespace Basket.API.Application.Features.Basket.Commands.UpdateBasket;

public class UpdateBasketCommand:IRequest
{
    public string BuyerId { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
}