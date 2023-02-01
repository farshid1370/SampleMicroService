namespace Catalog.Domain.DomainEvents;

public class CatalogShortageHasOccurredDomainEventHandler:INotificationHandler<CatalogShortageHasOccurredDomainEvent>
{
    private readonly ISupplierRepository _supplierRepository;

    public CatalogShortageHasOccurredDomainEventHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task Handle(CatalogShortageHasOccurredDomainEvent notification, CancellationToken cancellationToken)
    {
        var suppliersList = await _supplierRepository.GetByType(notification.CatalogItem.CatalogTypeId);
        foreach (var supplier in suppliersList)
        {
            supplier.AddSupplierItem(supplier.Id, notification.RequiredInventory);

            _supplierRepository.Update(supplier);
        }

        await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}