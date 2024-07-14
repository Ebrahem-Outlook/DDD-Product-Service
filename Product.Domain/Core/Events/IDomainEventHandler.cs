using MediatR;

namespace Product.Domain.Core.Events;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{

}
