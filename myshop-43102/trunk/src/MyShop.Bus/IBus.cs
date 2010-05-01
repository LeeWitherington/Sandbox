using System;
using System.Collections.Generic;

namespace MyShop.Bus
{
    /// <summary>
    /// A bus that can publish messages to handlers.
    /// </summary>
    /// <typeparam name="T">The type of the messages that will be published.</typeparam>
    public interface IBus<T> where T : IMessage
    {
        /// <summary>
        /// Publishes the message to the handlers.
        /// </summary>
        /// <param name="message">The message to publish.</param>
        /// <exception cref="ArgumentNullException">Thrown when <i>message</i> was null.</exception>
        /// <exception cref="NoHandlerRegisteredForMessageException">Thrown when no handler was found for the specified message.</exception>
        void Publish(T message);

        /// <summary>
        /// Publishes the messages to the handlers.
        /// </summary>
        /// <param name="messages">The messages to publish.</param>
        /// <exception cref="ArgumentNullException">Thrown when <i>messages</i> was null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a instance in <i>messages</i> was null.</exception>
        /// <exception cref="NoHandlerRegisteredForMessageException">Thrown when no handler was found for one of the specified messages.</exception>
        void Publish(IEnumerable<T> messages);

        /// <summary>
        /// Register a handler for a specific message type.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
        /// <param name="handler">The handler that handles the specified message.</param>
        void RegisterHandler<TMessage>(IMessageHandler<TMessage> handler) where TMessage : T;
    }
}