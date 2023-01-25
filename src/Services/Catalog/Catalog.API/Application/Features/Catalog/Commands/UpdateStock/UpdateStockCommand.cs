namespace Catalog.API.Application.Features.Catalog.Commands.UpdateStock;

public class UpdateStockCommand:IRequest<int>
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }

    
}