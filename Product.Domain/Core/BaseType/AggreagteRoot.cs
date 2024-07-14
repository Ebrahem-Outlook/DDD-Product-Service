using Product.Domain.Core.Events;

namespace Product.Domain.Core.BaseType;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    protected AggregateRoot(Guid id) : base(id) { }

    protected AggregateRoot() : base() { }

    private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    public void RaiseDomainEvent(IDomainEvent @event) => domainEvents.Add(@event);

    public void ClearDomainEvent() => domainEvents.Clear();
}

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void RaiseDomainEvent(IDomainEvent @event);

    void ClearDomainEvent() ;
}