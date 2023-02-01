namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class Supplier:Entity,IAggregateRoot
{
    private Guid _id;
    private Guid _catalogTypeId;
    private string _name;
    private Address _address;
    private readonly List<SupplierItem> _supplierItems;

    protected Supplier(Guid id, string name)
    {
        _id = id;
        _supplierItems = new List<SupplierItem>();
        _name = name;
    }
    public Supplier(Guid id, Guid catalogTypeId, string name, Address address):this(id,name)
    {
        _address = address;
        _catalogTypeId = catalogTypeId;
    }
    public Guid Id => _id;
    public Guid CatalogTypeId => _catalogTypeId;
    public string Name => _name;
    public Address Address => _address;
    public IReadOnlyCollection<SupplierItem> SupplierItems => _supplierItems;

    public void SetName(string? newName)
    {
        _name = newName ?? throw new CatalogDomainException("SupplierName is required");
    }
    public void AddSupplierItem(Guid supplierId, int requestedNumber)
    {
        _supplierItems.Add(new SupplierItem(new Guid(),supplierId,requestedNumber));
    }
}