namespace Common.Integration;

public interface IIntegrationMessage
{
    public Guid Id { get; }
    public DateTime CreationDate { get; }
}