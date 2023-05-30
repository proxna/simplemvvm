namespace SimpleMvvm.Messaging
{
    /// <summary>
    /// Defines a messenger that can be used to send and receive messages.
    /// </summary>
    public interface IMessenger
    {
        /// <summary>
        /// Subscribes to a message type.
        /// </summary>
        /// <typeparam name="TMessage"> The type of message to subscribe to. </typeparam>
        /// <param name="handler"> The handler to invoke when a message of the specified type is published. </param>
        void Subscribe<TMessage>(Action<TMessage> handler);

        /// <summary>
        /// Unsubscribes from a message type.
        /// </summary>
        /// <typeparam name="TMessage"> The type of message to unsubscribe from. </typeparam>
        /// <param name="handler"> The handler to unsubscribe. </param>
        void Unsubscribe<TMessage>(Action<TMessage> handler);

        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <typeparam name="TMessage"> The type of message to publish. </typeparam>
        /// <param name="message"></param>
        void Publish<TMessage>(TMessage message);
    }
}
