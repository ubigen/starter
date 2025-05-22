namespace Starter.Api.Shared.Events;

public interface IEvent
{
    DateTimeOffset OccurredAt { get; }
}