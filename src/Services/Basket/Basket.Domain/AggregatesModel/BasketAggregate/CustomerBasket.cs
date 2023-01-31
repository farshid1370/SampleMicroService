namespace Basket.Domain.AggregatesModel.BasketAggregate;

public class CustomerBasket : Entity, IAggregateRoot
{
    private Guid _id;
    private string _buyerId;
    private readonly List<BasketItem> _items;

    public CustomerBasket(string buyerId)
    {

        _id = new Guid();
        _buyerId = buyerId;
        _items = new List<BasketItem>();
    }
    public Guid Id=> _id;
    public string BuyerId => _buyerId;
    public IReadOnlyCollection<BasketItem> Items => _items;

    public void AddBasketItem(Guid id, int quantity, Guid productId, string productName, decimal unitPrice, decimal oldUnitPrice)
    {
        _items.Add(new BasketItem(id,_id, quantity, productId, productName, unitPrice, oldUnitPrice));
    }
   
}