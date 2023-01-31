namespace Basket.API.Application.Features.Basket.Queries.GetCustomerBasket;

public class GetCustomerBasketQuery : IRequest<CustomerBasketVM>
{
    public string CustomerId { get; set; }
}