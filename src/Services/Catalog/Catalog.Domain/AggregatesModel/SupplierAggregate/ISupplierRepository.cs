namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public interface ISupplierRepository : IRepository<Supplier>
{
    Supplier Add(Supplier item);
    void Update(Supplier item);
    Task<IEnumerable<Supplier>> GetByType(Guid typeId);
    Task<Supplier> GetById(Guid id);
}