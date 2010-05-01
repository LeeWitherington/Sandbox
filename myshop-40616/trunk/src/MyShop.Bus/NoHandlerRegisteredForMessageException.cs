using System;

namespace MyShop.Bus
{
    /// <summary>
    /// The exception that is thrown when no handler was found for a certain message.
    /// </summary>
    [Serializable]
    public class NoHandlerRegisteredForMessageException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoHandlerRegisteredForMessageException"/> class.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        public NoHandlerRegisteredForMessageException(Type messageType)
            : base("No handler found for message " + messageType.FullName)
        {
            MessageType = messageType;
        }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public Type MessageType { get; private set; }
    }
}