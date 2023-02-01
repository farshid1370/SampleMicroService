using Basket.Domain.SeedWork;

namespace Basket.Infrastructure.Repositoris;

public class BasketRepository:IBasketRepository
{
    private readonly BasketContext _context;

    public BasketRepository(BasketContext context)
    {
        _context = context;

    }
    public IUnitOfWork UnitOfWork => _context;
    public async Task<CustomerBasket> GetBasket(string buyerId)
    {
        var basket = await _context.CustomerBaskets.FirstOrDefaultAsync(b => b.BuyerId == buyerId);
        return basket;
    }
    public async Task<IEnumerable<BasketItem>> GetBasketItems(Guid basketId)
    {
        var basketItems = await _context.BasketItems.Where(b => b.CustomerBasketId == basketId).ToListAsync();
        return basketItems;
    }


    public async Task<IEnumerable<string>> GetUsers()
    {
        var users = await _context.CustomerBaskets.Select(b => b.BuyerId).ToListAsync();
        return users;
    }

    public  void UpdateBasket(CustomerBasket customerBasket)
    {
        _context.Entry(customerBasket).State = EntityState.Modified;
    }

    public void AddBasketItems(IEnumerable<BasketItem> list)
    {
        _context.BasketItems.AddRange(list);
    }
}