﻿namespace IntegrationEventEF.Service;

public interface IIntegrationEventLogService
{
    Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
    Task SaveEventAsync(IIntegrationMessage @event, IDbContextTransaction transaction);
    Task MarkEventAsPublishedAsync(Guid eventId);
    Task MarkEventAsInProgressAsync(Guid eventId);
    Task MarkEventAsFailedAsync(Guid eventId);
    Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPublishedFailedToPublishAsync(int maxTimeSents);
}