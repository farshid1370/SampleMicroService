namespace Catalog.API.Application.Features.Catalog.Commands.UpdateNamePrice;

public class UpdateNameAndPriceCommand:IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}