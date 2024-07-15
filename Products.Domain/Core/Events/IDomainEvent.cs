using MediatR;

namespace Products.Domain.Core.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccuresOn { get; }
}
