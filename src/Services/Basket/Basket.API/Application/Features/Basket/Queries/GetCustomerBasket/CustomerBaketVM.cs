namespace Basket.API.Application.Features.Basket.Queries.GetCustomerBasket;

public class CustomerBasketVM
{
    public string BuyerId { get; set; }
    public List<BasketItemVM> BasketItems { get; set; }
}

public class BasketItemVM
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal OldUnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
}