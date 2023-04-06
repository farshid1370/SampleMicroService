namespace Catalog.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly CatalogContext _context;

    public SupplierRepository(CatalogContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;
    public Supplier Add(Supplier item)
    {
        return _context.Suppliers.Add(item).Entity;
    }

    public void Update(Supplier item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public async Task<IEnumerable<Supplier>> GetByType(Guid typeId)
    {
        var suppliers = await _context.Suppliers.Where(s => s.CatalogTypeId==typeId)
            .ToListAsync();
        return suppliers;
    }

    public async Task<Supplier> GetById(Guid id)
    {
        var item = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
        if (item != null)
        {
            await _context.Entry(item).Collection(s => s.SupplierItems).LoadAsync();
        }
        return item;
    }

    public async Task<int> GetTotalCount()
    {
        var totalItems = await _context.Suppliers.CountAsync();
        return totalItems;
    }

    public async Task<IEnumerable<Supplier>> GetByPaging(int pageSize, int PageNumber)
    {
        var itemsOnPage = await _context.Suppliers
            .OrderBy(c => c.Name)
            .Skip(pageSize * (PageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
        return itemsOnPage;
    }
}