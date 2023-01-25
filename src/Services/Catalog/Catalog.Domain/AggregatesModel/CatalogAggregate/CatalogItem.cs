using Catalog.Domain.DomainEvents;

namespace Catalog.Domain.AggregatesModel.CatalogAggregate;

public class CatalogItem : Entity, IAggregateRoot
{
    public CatalogItem(string name, int price, Guid catalogTypeId, int availableStock, int minStockThreshold, int maxStockThreshold)
    {
        Name = string.IsNullOrEmpty(name) ? throw new CatalogDomainException("The name is empty and must be entered") : name;
        Price = price <= 0 ? throw new CatalogDomainException("The price must be than 0.") : price;
        CatalogTypeId = catalogTypeId;
        AvailableStock = availableStock;
        if (MaxStockThreshold < AvailableStock)
        {
            throw new CatalogDomainException("Max stock threshold not must be less than available Stock");
        }
        if (MaxStockThreshold < MinStockThreshold)
        {
            throw new CatalogDomainException("Max stock threshold not must be less than stock threshold");
        }
        MinStockThreshold = minStockThreshold;
        MaxStockThreshold = maxStockThreshold;
    }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public Guid CatalogTypeId { get; private set; }
    public int AvailableStock { get; private set; }
    public int MinStockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }


    public void UpdateName(string newName)
    {
        Name = string.IsNullOrEmpty(newName) ? throw new CatalogDomainException("The new name is empty and must be entered") : newName;
    }

    public void UpdatePrice(int newPrice)
    {
        if (newPrice <= 0) throw new CatalogDomainException("The price must be than 0.");
        if (newPrice != Price)
        {

            AddDomainEvent(new CatalogPriceChangedDomainEvent(newPrice, Price, this));
        }

        Price = newPrice;
    }

    public int AddStok(int quantity)
    {
        var original = AvailableStock;
        if (original + quantity > MaxStockThreshold)
        {
            AvailableStock = MaxStockThreshold;
        }
        else
        {
            AvailableStock += quantity;
        }

        return AvailableStock - original;
    }

    public int RemoveStock(int quantity)
    {

        if (AvailableStock == 0)
        {
            throw new CatalogDomainException($"Empty stock, product item {Name} is sold out");
        }

        if (AvailableStock - quantity < 0)
        {
            throw new CatalogDomainException($"Item units desired should be greater than zero");
        }

        var removeQuantity = Math.Min(AvailableStock, quantity);
        AvailableStock -= removeQuantity;
        if (AvailableStock <= MinStockThreshold)
        {
            AddDomainEvent(new CatalogShortageHasOccurredDomainEvent(MaxStockThreshold - AvailableStock, this));
        }
        return removeQuantity;
    }


}