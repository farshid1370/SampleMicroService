namespace Catalog.Domain.AggregatesModel.CatalogAggregate;

public interface ICatalogRepository : IRepository<CatalogItem>
{
    Task<CatalogItem> Add (CatalogItem item);
    void Update (CatalogItem item);
    Task<IEnumerable<CatalogItem>> Get(Guid[] ids);
    Task<CatalogItem> GetById (Guid id);
    Task<IEnumerable<CatalogItem>> GetByPaging(int pageSize, int PageNumber);
    Task<int> GetTotalCount();

}