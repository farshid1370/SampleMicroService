namespace Basket.API.Application.Features.Basket.Commands.UpdateBasketCatalogPrice;

public class UpdateBasketCatalogPriceCommand:IRequest
{
    public Guid CatalogId { get; set; }
    public decimal NewPrice { get; set; }
    public decimal OldPrice { get; set; }
}