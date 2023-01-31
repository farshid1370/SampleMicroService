namespace Basket.Domain.AggregatesModel.BasketAggregate;

public class BasketItem : Entity
{
    private Guid _id;
    private Guid _customerBasketId;
    private int _quantity;
    private Guid _productId;
    private string _productName;
    private decimal _unitPrice;
    private decimal _oldUnitPrice;


    public BasketItem(Guid id,Guid customerBasketId, int quantity, Guid productId, string productName, decimal unitPrice, decimal oldUnitPrice)
    {
        _id = id;
        _customerBasketId = customerBasketId;
        _quantity = quantity < 1 ? throw new BasketDomainException("Invalid number of units Quantity") : quantity;
        _productId = productId;
        _productName = productName;
        _unitPrice = unitPrice;
        _oldUnitPrice = oldUnitPrice;
    }
    public Guid Id => _id;
    public Guid CustomerBasketId => _customerBasketId;
    public Guid ProductId => _productId;
    public string ProductName => _productName;
    public decimal UnitPrice => _unitPrice;
    public decimal OldUnitPrice => _oldUnitPrice;
    public int Quantity => _quantity;

    public void SetNewPrice(decimal newPrice)
    {
        _oldUnitPrice = _unitPrice;
        _unitPrice = newPrice;
    }
}