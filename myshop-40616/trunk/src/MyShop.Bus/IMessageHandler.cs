namespace MyShop.Bus
{
    /// <summary>
    /// A handler that can handle a certain message type.
    /// </summary>
    /// <typeparam name="T">The type of the message it can handle.</typeparam>
    public interface IMessageHandler<T> where T : IMessage
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Handle(T message);
    }
}