namespace Basket.API.Grpc.ClientServices;

public interface ICatalogService
{
    Task<int?> GetCatalogPrice(Guid catalogId);
}