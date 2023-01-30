namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class SupplierItem : Entity
{
    private Guid _id;
    private Guid _supplierId;
    private int _requestNumber;
    private Guid _catalogTypeId;
    public SupplierItem(Guid id, Guid supplierId, int requestNumber, Guid catalogTypeId)
    {
        _id = id;
        _supplierId = supplierId;
        _requestNumber = requestNumber;
        _catalogTypeId = catalogTypeId;
    }
    public Guid Id => _id;
    public Guid SupplierId => _supplierId;
    public int RequestNumber => _requestNumber;
    public Guid CatalogTypeId => _catalogTypeId;
}