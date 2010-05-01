using System;
using System.Collections.Generic;
using MyShop.Events;

namespace MyShop.Domain.Storage
{
    public interface IEventStore
    {
        /// <summary>
        /// Get all events provided by an specified event provider.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<HistoricalEvent> GetAllEventsForEventProvider(Guid id);

        /// <summary>
        /// Save all events from a specific event provider.
        /// </summary>
        /// <exception cref="ConcurrencyException">Occurs when there is already a newer version of the event provider stored in the event store.</exception>
        /// <param name="provider">The provider that should be saved.</param>
        IEnumerable<IEvent> Save(IEventProvider provider);
    }
}