namespace Catalog.API.Application.Features.Catalog.Queries.GetSuppliersList
{
    public class SuppliersListVM
    {
        public long TotalCount { get; set; }

        public IEnumerable<SuppliersListItemVM> Data { get; set; }
    }

    public class SuppliersListItemVM
    {
        public Guid Id { get; set; }
        public Guid CatalogTypeId { get; set; }
        public string Name { get; set; } 
        public Address Address { get; set; }

    }
}
