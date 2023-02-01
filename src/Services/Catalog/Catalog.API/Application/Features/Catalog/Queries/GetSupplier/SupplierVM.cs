using System.Security.Cryptography;

namespace Catalog.API.Application.Features.Catalog.Queries.GetSupplier;

public class SupplierVM
{
    public Guid Id { get; set; }

    public Guid CatalogTypeId { get; set; }
    public string Name { get; set; }
    public SupplierAddresVM Address { get; set; }
    public List<SupplierItemVM> SupplierItems { get; set; }
   
}


