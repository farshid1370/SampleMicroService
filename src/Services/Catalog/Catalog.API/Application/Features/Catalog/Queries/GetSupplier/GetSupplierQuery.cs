namespace Catalog.API.Application.Features.Catalog.Queries.GetSupplier;

public class GetSupplierQuery:IRequest<SupplierVM>
{
    public Guid SupplierId { get; set; }
}