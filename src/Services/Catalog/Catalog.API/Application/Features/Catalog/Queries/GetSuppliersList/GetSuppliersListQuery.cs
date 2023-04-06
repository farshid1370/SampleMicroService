namespace Catalog.API.Application.Features.Catalog.Queries.GetSuppliersList
{
    public class GetSuppliersListQuery :IRequest<SuppliersListVM>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

    }
}
