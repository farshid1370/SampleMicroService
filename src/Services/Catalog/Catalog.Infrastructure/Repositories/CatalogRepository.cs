using Catalog.Domain.AggregatesModel.CatalogAggregate;
using Catalog.Domain.SeedWork;

namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository:ICatalogRepository
{
    public IUnitOfWork UnitOfWork { get; }
    public Task<CatalogItem> Add(CatalogItem item)
    {
        throw new NotImplementedException();
    }

    public void Update(CatalogItem item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> Get(Guid[] ids)
    {
        throw new NotImplementedException();
    }

    public Task<CatalogItem> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetByPaging(int pageSize, int PageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalCount()
    {
        throw new NotImplementedException();
    }
}