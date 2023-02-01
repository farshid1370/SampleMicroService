namespace Basket.Domain.AggregatesModel.BasketAggregate;

public class CustomerBasket : Entity, IAggregateRoot
{
    private Guid _id;
    private string _buyerId;
    private readonly List<BasketItem> _items;

    protected CustomerBasket()
    {
        _id = new Guid();
        _items = new List<BasketItem>();
    }
    public CustomerBasket(string buyerId):this()
    {
        _buyerId = buyerId;
    }
    public Guid Id=> _id;
    public string BuyerId => _buyerId;
    public IReadOnlyCollection<BasketItem> Items => _items;

    public void AddBasketItem( int quantity, Guid productId, string productName, decimal unitPrice, decimal oldUnitPrice)
    {
        _items.Add(new BasketItem(_id, quantity, productId, productName, unitPrice, oldUnitPrice));
    }
   
}