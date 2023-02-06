namespace Basket.Domain.AggregatesModel.BasketAggregate;

public interface IBasketRepository : IRepository<CustomerBasket>
{
    Task<CustomerBasket> GetBasket(string buyerId);
    Task<IEnumerable<BasketItem>> GetBasketItems(Guid basketId);
    Task<IEnumerable<string>> GetUsers();
    void UpdateBasket(CustomerBasket customerBasket);
 

}