﻿namespace Common.Integration;

public record IntegrationMessage : IIntegrationMessage
{
    public IntegrationMessage()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationMessage(Guid Id, DateTime CreationDate)
    {
        this.Id = Id;
        this.CreationDate = CreationDate;
    }

    [JsonInclude]
    public Guid Id { get; private init; }

    [JsonInclude]
    public DateTime CreationDate { get; private init; }

}