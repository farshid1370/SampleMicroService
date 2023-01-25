namespace Catalog.Domain.AggregatesModel.SupplierAggregate;

public class SupplierAddress:ValueObject
{
    public SupplierAddress(string street, string city)
    {
        Street = street;
        City = city;

    }
    public string Street { get; private set; }
    public string City { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
    }
}