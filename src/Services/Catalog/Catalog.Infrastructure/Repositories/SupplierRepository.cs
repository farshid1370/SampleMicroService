using Catalog.Domain.AggregatesModel.SupplierAggregate;
using Catalog.Domain.SeedWork;

namespace Catalog.Infrastructure.Repositories;

public class SupplierRepository:ISupplierRepository
{
    public IUnitOfWork UnitOfWork { get; }
    public Task<Supplier> Add(Supplier item)
    {
        throw new NotImplementedException();
    }

    public void Update(Supplier item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> Get(Guid[] id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetByType(Guid typeId)
    {
        throw new NotImplementedException();
    }

    public Task<Supplier> GetById(int id)
    {
        throw new NotImplementedException();
    }
}