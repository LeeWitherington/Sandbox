using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using MyShop.Domain.Framework.DomainEventMapping;
using MyShop.Domain.Storage;
using MyShop.Events;

namespace MyShop.Domain.Framework
{
    /// <summary>
    /// Represents a method that will handle a specific event.
    /// </summary>
    /// <param name="e">The event to handle.</param>
    public delegate void DomainEventHandler<T>(T e) where T : IEvent;

    public abstract class AggregateRoot : IEventProvider
    {
        /// <summary>
        /// The logger to use for the current type.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected Type CurrentType
        {
            get
            {
                return GetType();
            }
        }

        /// <summary>
        /// Holds the methods that handle domain events.
        /// </summary>
        private readonly Dictionary<Type, DomainEventHandler<IEvent>> _eventHandlers =
            new Dictionary<Type, DomainEventHandler<IEvent>>();

        /// <summary>
        /// Holds the events that have been raised since the last accepted changes.
        /// </summary>
        private readonly Stack<IEvent> _events = new Stack<IEvent>();

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
        {
            InitializeHandlersFromRegisteredCreators();

// ReSharper disable DoNotCallOverridableMethodsInConstructor
            InitializeHandlers();
// ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        private void InitializeHandlersFromRegisteredCreators()
        {
            Log.DebugFormat("Initializing handlers for {0}.");

            var handlerFactories = MyShopWorld.Instance.IocContainer.GetAllInstances<IDomainEventHandlerFactory>();
            foreach(IDomainEventHandlerFactory factory in handlerFactories)
            {
                Log.DebugFormat("Initializing handlers from factory {0}.", factory.GetType().FullName);

                foreach(var handler in factory.CreateHandlersForAggregateRoot(this))
                {
                    RegisterHandler(handler);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="history">The history. This will be used to load the instance.</param>
        protected AggregateRoot(IEnumerable<HistoricalEvent> history) : this()
        {
            if(history == null) throw new ArgumentNullException("history");
            ((IEventProvider)this).LoadFromHistory(history);
        }

        /// <summary>
        /// Called within constructor to initialize the handlers.
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            // Nothing todo.
        }
#endregion

        #region IEventProvider Members

        /// <summary>
        /// Gets the global unique identifier.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Gets the version number of this instance.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Load the current provider from history.
        /// </summary>
        /// <remarks>This will clear all current events.</remarks>
        /// <param name="history">All historical events.</param>
        void IEventProvider.LoadFromHistory(IEnumerable<HistoricalEvent> history)
        {
            // Clear current events.
            _events.Clear();

            // Apply every event.
            foreach (HistoricalEvent evnt in history)
            {
                ApplyEvent(evnt);
            }

            // Update the version number to the number of events.
            UpdateVersion(history.Count());
        }

        /// <summary>
        /// Get all events that have been happend since creation or the last acceptance.
        /// </summary>
        /// <returns>
        /// A events that have been happend since creatino or the last acceptance.
        /// </returns>
        IEnumerable<IEvent> IEventProvider.GetChanges()
        {
            return _events.ToArray();
        }

        /// <summary>
        /// Accept the current changes.
        /// </summary>
        void IEventProvider.AcceptChanges()
        {
            // Set the new version.
            int numberOfEvents = _events.Count;
            int newVersion = Version + numberOfEvents;
            UpdateVersion(newVersion);

            // Discard all events.
            _events.Clear();
        }

        #endregion

        /// <summary>
        /// Registers the handler for a specific event.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <exception cref="ArgumentNullException">Thrown when <c>handler</c> is null.</exception>
        /// <exception cref="HandlerForEventTypeAlreadyRegisteredException">Thrown when there is already a handler registed for the specified event type.</exception>
        protected void RegisterHandler(DomainEventHandler handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");

            if (_eventHandlers.ContainsKey(handler.EventType))
                throw new HandlerForEventTypeAlreadyRegisteredException(handler.EventType);

            _eventHandlers.Add(handler.EventType, handler.EventHandler);
        }

        /// <summary>
        /// Registers the handler for a specific event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handlerMethod">The handler method.</param>
        /// <exception cref="ArgumentNullException">Thrown when <c>handler</c> is null.</exception>
        /// <exception cref="HandlerForEventTypeAlreadyRegisteredException">Thrown when there is already a handler registed for the specified event type.</exception>
        protected void RegisterHandler<T>(DomainEventHandler<T> handlerMethod) where T : IEvent
        {
            var handler = new DomainEventHandler(typeof (T), (e) => handlerMethod((T) e));
            RegisterHandler(handler);
        }

        /// <summary>
        /// Applies the event.
        /// </summary>
        /// <param name="e">The event.</param>
        /// <exception cref="ArgumentNullException">Thrown when <c>e</c> was null.</exception>
        /// <exception cref="HandlerForEventNotFoundException">Throw when there was no handler found for the specified event.</exception>
        protected void ApplyEvent(IEvent e)
        {
            ApplyEvent(e, false);
        }

        /// <summary>
        /// Applies the historical event.
        /// </summary>
        /// <param name="e">The historical event.</param>
        protected void ApplyEvent(HistoricalEvent e)
        {
            ApplyEvent(e.Event, true);
        }

        /// <summary>
        /// Applies the event.
        /// </summary>
        /// <param name="e">The event.</param>
        /// <param name="isHistorical">if set to <c>true</c> the event is historical.<remarks>This is <c>true</c> when an event is loaded from an <see cref="EventStore"/>.</remarks></param>
        /// <exception cref="ArgumentNullException">Thrown when <c>e</c> was null.</exception>
        /// <exception cref="HandlerForEventNotFoundException">Throw when there was no handler found for the specified event.</exception>
        protected void ApplyEvent(IEvent e, Boolean isHistorical)
        {
            // Make sure e is not null.
            if (e == null) throw new ArgumentNullException("e");

            // Get the type of the event.
            DomainEventHandler<IEvent> handler;
            Type eventType = e.GetType();

            // Find the handler for the event.
            if (!_eventHandlers.TryGetValue(eventType, out handler))
            {
                // No handler was found, throw exception.
                throw new HandlerForEventNotFoundException(eventType);
            }

            // Invoke handler.
            handler.Invoke(e);

            // If the event is not historical, store it.
            if (!isHistorical)
            {
                // Store the event.
                _events.Push(e);

                // Mark current instance as dirty.
                // This means that it will be saved when
                // the unit of work is accepted.
                UnitOfWork.Current.RegisterDirty(this);
            }
        }

        private void UpdateVersion(int newVersion)
        {
            if (Version > newVersion)
                throw new ArgumentOutOfRangeException("newVersion", "The new version can't be lower than the current.");

            Version = newVersion;
        }
    }
}