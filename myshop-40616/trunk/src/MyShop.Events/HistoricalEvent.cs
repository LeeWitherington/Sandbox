using System;

namespace MyShop.Events
{
    /// <summary>
    /// Represents an event that has already happend.
    /// </summary>
    public class HistoricalEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoricalEvent"/> class.
        /// </summary>
        /// <param name="timeStamp">The moment in time that the event happened.</param>
        /// <param name="evnt">The event that happened.</param>
        /// <exception cref="ArgumentNullException">Thrown when <i>evnt</i> is null.</exception>
        public HistoricalEvent(DateTime timeStamp, IEvent evnt)
        {
            if (evnt == null) throw new ArgumentNullException("evnt");

            TimeStamp = timeStamp;
            Event = evnt;
        }

        /// <summary>
        /// Gets the moment in time that the event happened.
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        /// <summary>
        /// Gets the version of the provider at the time the event occured.
        /// </summary>
        /// <value>The provider version at the time the event occured.</value>
        public int ProviderVersion { get; private set; }

        /// <summary>
        /// Gets the event.
        /// </summary>
        public IEvent Event { get; private set; }
    }
}