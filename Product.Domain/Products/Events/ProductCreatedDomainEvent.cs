using Products.Domain.Core.Events;

namespace Products.Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(Product Product) : DomainEvent;
