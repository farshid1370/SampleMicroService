namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> Add(Supplier item);
    void Update(Supplier item);
    Task<IEnumerable<Supplier>> Get(Guid[] id);
    Task<IEnumerable<Supplier>> GetByType(Guid typeId);
    Task<Supplier> GetById(int id);
}