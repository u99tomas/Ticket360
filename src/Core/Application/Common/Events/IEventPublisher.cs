using Ticket360.Shared.Events;

namespace Ticket360.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}