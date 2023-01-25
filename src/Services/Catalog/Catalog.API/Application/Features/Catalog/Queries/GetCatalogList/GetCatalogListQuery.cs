namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalogList;

public class GetCatalogListQuery:IRequest<CatalogListVM>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}