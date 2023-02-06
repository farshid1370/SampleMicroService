namespace Basket.API.Application.Features.Basket.Queries.GetCustomerBasket;

public class GetCustomerBasketQueryHandler : IRequestHandler<GetCustomerBasketQuery, CustomerBasketVM>
{
    private readonly IBasketRepository _repository;
    private readonly ICatalogService _catalogService;
    public GetCustomerBasketQueryHandler(IBasketRepository repository, ICatalogService catalogService)
    {
        _repository = repository;
        _catalogService = catalogService;
    }

    public async Task<CustomerBasketVM> Handle(GetCustomerBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await _repository.GetBasket(request.CustomerId);
       
        if (basket == null) return null;
      
        var customerBasketVM = new CustomerBasketVM
        {
            BasketItems = basket.BasketItems.Select(p => new BasketItemVM
            {
                Id = p.Id,
                OldUnitPrice = p.OldUnitPrice,
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
            }).ToList(),
            BuyerId = basket.BuyerId
        };

        foreach (var item in customerBasketVM.BasketItems)
        {
            item.UnitPrice = (decimal) await _catalogService.GetCatalogPrice(item.ProductId);
        }

        return customerBasketVM;

    }
}