namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class Supplier:Entity,IAggregateRoot
{
    private Guid _id;
    private string _name;
    private Address _address;
    private readonly List<SupplierItem> _supplierItems;

    private Supplier(Guid id, string name)
    {
        _id = id;
        _supplierItems = new List<SupplierItem>();
        _name = name;
    }
    public Supplier(Guid id, string name, Address address):this(id,name)
    {
        _address = address;
    }
    public Guid Id => _id;
    public string Name => _name;
    public Address Address => _address;
    public IReadOnlyCollection<SupplierItem> SupplierItems => _supplierItems;

    public void SetName(string? newName)
    {
        _name = newName ?? throw new CatalogDomainException("SupplierName is required");
    }
    public void AddSupplierItem(Guid supplierId, Guid catalogItemId, int requestedNumber)
    {
        _supplierItems.Add(new SupplierItem(new Guid(),supplierId,requestedNumber,catalogItemId));
    }
}