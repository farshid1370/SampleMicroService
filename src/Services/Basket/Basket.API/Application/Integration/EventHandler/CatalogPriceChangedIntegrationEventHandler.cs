using Basket.API.Application.Features.Basket.Commands.UpdateBasketCatalogPrice;
using MassTransit;

namespace Basket.API.Application.Integration.EventHandler;

public class CatalogPriceChangedIntegrationEventHandler:IConsumer<CatalogPriceChangedIntegrationEvent>
{
    private readonly IMediator _mediator;

    public CatalogPriceChangedIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<CatalogPriceChangedIntegrationEvent> context)
    {
        await _mediator.Send(new UpdateBasketCatalogPriceCommand()
        {
            CatalogId = context.Message.CatalogID,
            NewPrice = context.Message.NewPrice,
            OldPrice = context.Message.OldPrice
        });
    }
}