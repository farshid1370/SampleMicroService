namespace Catalog.API.Application.Features.Catalog.Queries.GetSuppliersList
{
    public class GetSuppliersListQueryHandler : IRequestHandler<GetSuppliersListQuery,SuppliersListVM>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSuppliersListQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }


        public async Task<SuppliersListVM> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {

            var total = await _supplierRepository.GetTotalCount();
            var suppliers = await _supplierRepository.GetByPaging(request.PageSize, request.PageNumber);

            var result = new SuppliersListVM
            {
                TotalCount = total,
                Data = suppliers.Select(s => new SuppliersListItemVM
                {
                    Id = s.Id,
                    CatalogTypeId = s.CatalogTypeId,
                    Name = s.Name,
                    Address = s.Address
                })
            };

            return result;
        }
    }
}
