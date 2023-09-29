using Ticket360.Shared.Events;

namespace Ticket360.Domain.Common.Contracts;

public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}