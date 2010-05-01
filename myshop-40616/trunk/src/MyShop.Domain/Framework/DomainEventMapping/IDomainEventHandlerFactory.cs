using System.Collections.Generic;

namespace MyShop.Domain.Framework.DomainEventMapping
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<DomainEventHandler> CreateHandlersForAggregateRoot(AggregateRoot aggregateRoot);
    }
}