namespace Basket.Domain.AggregatesModel.BasketAggregate;

public class CustomerBasket : Entity, IAggregateRoot
{
    private Guid _id;
    private string _buyerId;
    private readonly List<BasketItem> _basketItems;

    public CustomerBasket(string buyerId)
    {
        _id = new Guid();
        _basketItems = new List<BasketItem>();
        _buyerId = buyerId;
    }
    public Guid Id=> _id;
    public string BuyerId => _buyerId;
    public IReadOnlyCollection<BasketItem> BasketItems => _basketItems;

    public void AddBasketItem( int quantity, Guid productId, string productName, decimal unitPrice, decimal oldUnitPrice)
    {
        _basketItems.Add(new BasketItem(_id, quantity, productId, productName, unitPrice, oldUnitPrice));
    }
   
}