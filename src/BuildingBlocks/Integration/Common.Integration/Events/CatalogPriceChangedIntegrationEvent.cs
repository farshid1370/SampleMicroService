namespace Common.Integration.Events;

public record CatalogPriceChangedIntegrationEvent: IntegrationEvent
{
    public CatalogPriceChangedIntegrationEvent(Guid CatalogID, decimal NewPrice, decimal OldPrice)
    {
        this.CatalogID = CatalogID;
        this.NewPrice = NewPrice;
        this.OldPrice = OldPrice;
    }

    [JsonInclude]
    public Guid CatalogID { get; private init; }
    [JsonInclude]
    public decimal NewPrice { get; private init; }
    [JsonInclude]
    public decimal OldPrice { get; private init; }
}