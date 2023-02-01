namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class SupplierItem : Entity
{
    private Guid _id;
    private Guid _supplierId;
    private int _requestNumber;
    
    public SupplierItem(Guid id, Guid supplierId, int requestNumber)
    {
        _id = id;
        _supplierId = supplierId;
        _requestNumber = requestNumber;
       
    }
    public Guid Id => _id;
    public Guid SupplierId => _supplierId;
    public int RequestNumber => _requestNumber;
   
}