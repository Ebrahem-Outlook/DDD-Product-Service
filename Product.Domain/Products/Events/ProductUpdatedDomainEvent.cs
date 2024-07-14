using Product.Domain.Core.Events;

namespace Product.Domain.Products.Events;

public sealed record ProductUpdatedDomainEvent(Product Product) : DomainEvent;
