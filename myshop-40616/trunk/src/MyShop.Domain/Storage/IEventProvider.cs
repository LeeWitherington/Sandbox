using System;
using System.Collections.Generic;
using MyShop.Events;

namespace MyShop.Domain.Storage
{
    public interface IEventProvider
    {
        /// <summary>
        /// Get the global unique identifier.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the version number.
        /// </summary>
        int Version { get; }

        /// <summary>
        /// Get all events that have been happend since creation or the last acceptance.
        /// </summary>
        /// <returns>A events that have been happend since creatino or the last acceptance.</returns>
        IEnumerable<IEvent> GetChanges();

        /// <summary>
        /// Load the current provider from history.
        /// </summary>
        /// <param name="history">All historical events.</param>
        void LoadFromHistory(IEnumerable<HistoricalEvent> history);

        /// <summary>
        /// Accept the current changes.
        /// </summary>
        void AcceptChanges();
    }
}