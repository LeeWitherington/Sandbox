using System;
using MyShop.Events;

namespace MyShop.Domain.Framework.DomainEventMapping
{
    /// <summary>
    /// Specifies that a method handles a specific <see cref="IEvent"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class HandlesEventAttribute : Attribute
    {
        /// <summary>
        /// Gets the type of the event that is handled by the method.
        /// </summary>
        public Type EventType // TODO: Isn't the event type allways the same as the first parameter of the handling method? In other words: do we need this?
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlesEventAttribute"/> class.
        /// </summary>
        /// <param name="eventType">Type of the event that is handled by the method.</param>
        /// <exception cref="ArgumentNullException">Throw when <i>eventType</i> is null.</exception>
        /// <exception cref="ArgumentException">Throw when type specified by the <i>eventType</i> parameter 
        /// does not implement the <see cref="IEvent"/> interface.</exception>
        public HandlesEventAttribute(Type eventType)
        {
            if (eventType == null) throw new ArgumentNullException("eventType");
            var iEventType = typeof (IEvent);

            if (!iEventType.IsAssignableFrom(eventType))
            {
                var message = String.Format("Specified type {0} is does not implement the {1} interface.",
                                            eventType.FullName, iEventType.FullName);
                throw new ArgumentException(message);
            }

            EventType = eventType;
        }
    }
}