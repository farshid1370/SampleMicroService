namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class Supplier:Entity,IAggregateRoot
{
    private readonly List<SupplierItem> _supplierItems;

    public Supplier(List<SupplierItem> supplierItems, string name, SupplierAddress address)
    {
        _supplierItems = supplierItems;
        Name = name;
        Address = address;
    }

    public string Name { get;private set; }
    public SupplierAddress Address { get;private set; }
    public IReadOnlyCollection<SupplierItem> SupplierItems => _supplierItems;

    public void SetName(string? newName)
    {
        Name = newName ?? throw new CatalogDomainException("SupplierName is required");
    }
    public void AddSupplierItem(Guid supplierId, Guid catalogItemId, int requestedNumber)
    {
        _supplierItems.Add(new SupplierItem(supplierId,requestedNumber,catalogItemId));
    }
}