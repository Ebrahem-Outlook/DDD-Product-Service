using Products.Domain.Core.Events;

namespace Products.Domain.Products.Events;

public sealed record ProductUpdatedDomainEvent(Product Product) : DomainEvent;
