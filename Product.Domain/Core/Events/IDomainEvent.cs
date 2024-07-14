using MediatR;

namespace Product.Domain.Core.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccuresOn { get; }
}
