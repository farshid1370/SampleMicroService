namespace Basket.API.Grpc.ClientServices;

public class CatalogService: ICatalogService
{
    private readonly Catalog.API.Grpc.Proto.Catalog.CatalogClient _catalogClient;

    public CatalogService(Catalog.API.Grpc.Proto.Catalog.CatalogClient catalogClient)
    {
        _catalogClient = catalogClient;
    }

    public async Task<int?> GetCatalogPrice(Guid catalogId)
    {
        var catalogPriceResponse = await _catalogClient.GetCatalogPriceAsync(new CatalogPriceRequest {CatalogId = catalogId.ToString()});
        return catalogPriceResponse.Price;
    }
}