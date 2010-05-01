using System;
using MyShop.Events;

namespace MyShop.Domain.Framework.DomainEventMapping
{
    public class DomainEventHandler
    {
        public Type EventType
        {
            get; private set;
        }
        public DomainEventHandler<IEvent> EventHandler
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DomainEventHandler(Type eventType, DomainEventHandler<IEvent> eventHandler)
        {
            EventType = eventType;
            EventHandler = eventHandler;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("EventType: {0}, EventHandler: {1}", EventType, EventHandler);
        }
    }
}