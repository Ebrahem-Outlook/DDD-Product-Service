namespace Products.Domain.Core.Events;

public record DomainEvent : IDomainEvent
{
    public DomainEvent()
    {

        Id = Guid.NewGuid();

        OccuresOn = DateTime.Now;
    }

    public Guid Id { get; }

    public DateTime OccuresOn { get; }
}
