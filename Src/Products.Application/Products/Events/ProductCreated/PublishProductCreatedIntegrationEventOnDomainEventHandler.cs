using Products.Domain.Core.Events;
using Products.Domain.Products.Events;

namespace Products.Application.Products.Events.ProductCreated;

internal class PublishProductCreatedIntegrationEventOnDomainEventHandler : IDomainEventHandler<ProductCreatedDomainEvent>
{


    public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
