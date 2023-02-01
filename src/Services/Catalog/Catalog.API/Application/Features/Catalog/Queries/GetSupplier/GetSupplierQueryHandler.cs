namespace Catalog.API.Application.Features.Catalog.Queries.GetSupplier;

public class GetSupplierQueryHandler:IRequestHandler<GetSupplierQuery,SupplierVM>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSupplierQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierVM> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
    {
        var supplierEntity =await _supplierRepository.GetById(request.SupplierId);
        var supplier = new SupplierVM
        {
            Id = supplierEntity.Id,
            Name = supplierEntity.Name,
            CatalogTypeId = supplierEntity.CatalogTypeId,
            Address = new SupplierAddresVM
            {
                City = supplierEntity.Address.City,
                Street = supplierEntity.Address.Street
            },
            SupplierItems = new List<SupplierItemVM>()
        };
        foreach (var item in supplierEntity.SupplierItems)
        {
            supplier.SupplierItems.Add(new SupplierItemVM
            {
                Id = item.Id,
                RequestNumber = item.RequestNumber

            });
        }

        
        return supplier;
    }
}