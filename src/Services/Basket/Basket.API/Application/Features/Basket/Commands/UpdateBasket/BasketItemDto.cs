namespace Basket.API.Application.Features.Basket.Commands.UpdateBasket;

public class BasketItemDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal OldUnitPrice { get; set; }
    public int Quantity { get; set; }
}