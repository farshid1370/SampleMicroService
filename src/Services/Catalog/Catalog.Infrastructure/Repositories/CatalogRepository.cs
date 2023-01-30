using Catalog.Domain.AggregatesModel.CatalogAggregate;
using Catalog.Domain.SeedWork;

namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly CatalogContext _context;

    public CatalogRepository(CatalogContext context)
    {
        _context = context;

    }
    public IUnitOfWork UnitOfWork => _context;
    public CatalogItem Add(CatalogItem item)
    {
        return _context.Add(item).Entity;

    }

    public void Update(CatalogItem item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public async Task<CatalogItem> GetById(Guid id)
    {
        var item = await _context.CatalogItems.FirstOrDefaultAsync(c => c.Id == id);
        return item;
    }

    public async Task<IEnumerable<CatalogItem>> GetByPaging(int pageSize, int PageNumber)
    {
        var itemsOnPage = await _context.CatalogItems
            .OrderBy(c => c.Name)
            .Skip(pageSize * (PageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
        return itemsOnPage;
    }

    public async Task<int> GetTotalCount()
    {
        var totalItems = await _context.CatalogItems.CountAsync();
        return totalItems;
    }
}