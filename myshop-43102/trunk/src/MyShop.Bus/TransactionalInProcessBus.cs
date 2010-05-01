using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;
using log4net;

namespace MyShop.Bus
{
    /// <summary>
    /// An simple in process bus. The transaction mechanism is based on <see cref="TransactionScope"/>.
    /// </summary>
    /// <typeparam name="T">The base type of the messages that can be published. It must be a class and implement the <see cref="IMessage"/> interface.</typeparam>
    public abstract class TransactionalInProcessBus<T> : IBus<T> where T : class, IMessage
    {
        /// <summary>
        /// Gets the log for this type.
        /// </summary>
        /// <value>The log.</value>
        protected abstract ILog Log
        {
            get;
        }

        /// <summary>
        /// Holds the handlers for specific messages.
        /// </summary>
        private readonly Dictionary<Type, IList<Action<IMessage>>> _handlers =
            new Dictionary<Type, IList<Action<IMessage>>>();

        /// <summary>
        /// Publishes the message to the handlers.
        /// </summary>
        /// <param name="message">The message to publish.</param>
        /// <exception cref="ArgumentNullException">Thrown when <i>message</i> was null.</exception>
        /// <exception cref="NoHandlerRegisteredForMessageException">Thrown when no handler was found for the specified message.</exception>
        [DebuggerStepThrough]
        public void Publish(T message)
        {
            if (message == null) throw new ArgumentNullException("message");

            IEnumerable<Action<IMessage>> handlers = GetHandlersForMessage(message);

            OnMessageReceived(message);

            using (var scope = new TransactionScope())
            {
                foreach (var handler in handlers)
                {
                    handler(message);
                }

                scope.Complete();
            }
        }

        /// <summary>
        /// Publishes the messages to the handlers.
        /// </summary>
        /// <param name="messages">The messages to publish.</param>
        /// <exception cref="ArgumentNullException">Thrown when <i>messages</i> was null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a instance in <i>messages</i> was null.</exception>
        /// <exception cref="NoHandlerRegisteredForMessageException">Thrown when no handler was found for one of the specified messages.</exception>
        [DebuggerStepThrough]
        public void Publish(IEnumerable<T> messages)
        {
            if (messages == null) throw new ArgumentNullException("messages");

            using (var scope = new TransactionScope())
            {
                foreach (T message in messages)
                {
                    Publish(message);
                }

                scope.Complete();
            }
        }

        /// <summary>
        /// Registers a handler for a specific message type.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="handler">The handler that handles these messages.</param>
        /// <exception cref="ArgumentNullException">Thrown when <i>handler</i> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        public void RegisterHandler<TMessage>(IMessageHandler<TMessage> handler) where TMessage : T
        {
            if (handler == null) throw new ArgumentNullException("handler");

            Type messageType = typeof (TMessage);
            Action<IMessage> action = CreationHandlerAction(handler);

            if (_handlers.ContainsKey(messageType))
            {
                _handlers[messageType].Add(action);
            }
            else
            {
                var list = new List<Action<IMessage>> {action};
                _handlers.Add(messageType, list);
            }

            Log.InfoFormat("Registered new handler for message {0}.", messageType.Name);
        }

        /// <summary>
        /// Gets the handlers for a message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">Thrown when no <i>message</i> is a null reference.</exception>
        /// <exception cref="NoHandlerRegisteredForMessageException">Thrown when no handler was registered for the specified message.</exception>
        /// <returns>All handlers that are registered for this message.</returns>
        [DebuggerStepThrough]
        protected IEnumerable<Action<IMessage>> GetHandlersForMessage(T message)
        {
            if(message == null) throw new ArgumentNullException("message");
            Type messageType = message.GetType();

            if (!_handlers.ContainsKey(messageType))
            {
                throw new NoHandlerRegisteredForMessageException(message.GetType());
            }

            return _handlers[messageType];
        }

        /// <summary>
        /// Called when an message is received.
        /// </summary>
        /// <param name="message">The received message.</param>
        [DebuggerStepThrough]
        protected virtual void OnMessageReceived(T message)
        {
            // Do nothing.
        }

        [DebuggerStepThrough]
        private static Action<IMessage> CreationHandlerAction<TMessage>(IMessageHandler<TMessage> handler)
            where TMessage : IMessage
        {
            return (m => handler.Handle((TMessage)m));
        }
    }
}