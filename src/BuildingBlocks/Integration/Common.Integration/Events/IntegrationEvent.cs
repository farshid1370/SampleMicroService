using System.Text.Json.Serialization;

namespace Common.Integration.Events;

public record IntegrationEvent : IntegrationMessage
{
    public IntegrationEvent() : base()
    {
    }

    [JsonConstructor]
    public IntegrationEvent(Guid Id, DateTime CreationDate) : base(Id, CreationDate)
    {
    }
}