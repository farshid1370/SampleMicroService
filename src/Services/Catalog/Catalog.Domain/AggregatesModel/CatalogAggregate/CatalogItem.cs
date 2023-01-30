using Catalog.Domain.DomainEvents;

namespace Catalog.Domain.AggregatesModel.CatalogAggregate;

public class CatalogItem : Entity, IAggregateRoot
{
    private Guid _id;
    private string _name;
    private int _price;
    private Guid _catalogTypeId;
    private int _availableStock;
    private int _minStockThreshold;
    private int _maxStockThreshold;
    public CatalogItem(Guid id,string name, int price, Guid catalogTypeId, int availableStock, int minStockThreshold, int maxStockThreshold)
    {
        _id= id;
        _name = string.IsNullOrEmpty(name) ? throw new CatalogDomainException("The name is empty and must be entered") : name;
        _price = price <= 0 ? throw new CatalogDomainException("The price must be than 0.") : price;
        _catalogTypeId = catalogTypeId;
        _availableStock = availableStock;
        if (maxStockThreshold < availableStock)
        {
            throw new CatalogDomainException("Max stock threshold not must be less than available Stock");
        }
        if (maxStockThreshold < minStockThreshold)
        {
            throw new CatalogDomainException("Max stock threshold not must be less than stock threshold");
        }
        _minStockThreshold = minStockThreshold;
        _maxStockThreshold = maxStockThreshold;
    }

    public Guid Id => _id;
    public string Name => _name;
    public int Price => _price;
    public Guid CatalogTypeId => _catalogTypeId;
    public int AvailableStock => _availableStock;
    public int MinStockThreshold => _minStockThreshold;
    public int MaxStockThreshold => _maxStockThreshold;


    public void UpdateName(string newName)
    {
        _name = string.IsNullOrEmpty(newName) ? throw new CatalogDomainException("The new name is empty and must be entered") : newName;
    }

    public void UpdatePrice(int newPrice)
    {
        if (newPrice <= 0) throw new CatalogDomainException("The price must be than 0.");
        if (newPrice != _price)
        {

            AddDomainEvent(new CatalogPriceChangedDomainEvent(newPrice, _price, this));
        }

        _price = newPrice;
    }

    public int AddStok(int quantity)
    {
        var original = _availableStock;
        if (original + quantity > _maxStockThreshold)
        {
            _availableStock = _maxStockThreshold;
        }
        else
        {
            _availableStock += quantity;
        }

        return _availableStock - original;
    }

    public int RemoveStock(int quantity)
    {

        if (_availableStock == 0)
        {
            throw new CatalogDomainException($"Empty stock, product item {_name} is sold out");
        }

        if (_availableStock - quantity < 0)
        {
            throw new CatalogDomainException($"Item units desired should be greater than zero");
        }

        var removeQuantity = Math.Min(_availableStock, quantity);
        _availableStock -= removeQuantity;
        if (_availableStock <= _minStockThreshold)
        {
            AddDomainEvent(new CatalogShortageHasOccurredDomainEvent(_maxStockThreshold - _availableStock, this));
        }
        return removeQuantity;
    }


}