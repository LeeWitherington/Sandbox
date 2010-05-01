using System;
using System.Collections.Generic;
using MyShop.Bus.EventBus;
using MyShop.Domain.Framework;
using MyShop.Domain.Storage;
using MyShop.Events;

namespace MyShop.Domain.Repositories
{
    public class DomainRepository
    {
        private readonly IEventBus _eventBus;
        private readonly IEventStore _store;

        public DomainRepository(IEventStore store, IEventBus eventBus)
        {
            _store = store;
            _eventBus = eventBus;
        }

        public AggregateRoot GetById(Type aggregateRootType, Guid id)
        {
            var events = _store.GetAllEventsForEventProvider(id);
            AggregateRoot aggregate = null;

            try
            {
                aggregate = (AggregateRoot)Activator.CreateInstance(aggregateRootType, events);
            }
            catch (MissingMethodException)
            {
                // TODO: Retrow exception with better details that there is no public ctor found that takes a IEnumerable<HistoricalEvent>.
                throw;
            }

            return aggregate;
        }

        public T GetById<T>(Guid id) where T : AggregateRoot
        {
            return (T)GetById(typeof (T), id);
        }

        internal void Save(AggregateRoot t)
        {
            // Save the events to the event store.
            IEnumerable<IEvent> events = _store.Save(t);

            // Send all events to the bus.
            _eventBus.Publish(events);

            // Accept the changes.
            IEventProvider provider = t;
            provider.AcceptChanges();
        }
    }
}