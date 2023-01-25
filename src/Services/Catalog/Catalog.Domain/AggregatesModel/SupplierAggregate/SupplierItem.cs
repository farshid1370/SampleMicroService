namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class SupplierItem
{
    public SupplierItem(Guid supplierId, int requestNumber, Guid catalogTypeId)
    {
        SupplierId = supplierId;
        RequestNumber = requestNumber;
        CatalogTypeId = catalogTypeId;
    }

    public Guid SupplierId { get;private set; }
    public int RequestNumber { get;private set; }

    public Guid CatalogTypeId { get; private set; }
}