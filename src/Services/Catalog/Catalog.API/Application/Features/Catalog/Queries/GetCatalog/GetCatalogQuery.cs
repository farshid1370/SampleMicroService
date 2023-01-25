namespace Catalog.API.Application.Features.Catalog.Queries.GetCatalog;

public class GetCatalogQuery : IRequest<CatalogVM>
{
    public Guid CatalogId { get; set; }
}