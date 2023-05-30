namespace SimpleMvvm.Messaging
{
    public class Messenger : IMessenger
    {
        private Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            var type = typeof(TMessage);
            if (!_subscribers.ContainsKey(type))
                _subscribers.Add(type, new List<Delegate>());
            _subscribers[type].Add(handler);
        }

        public void Unsubscribe<TMessage>(Action<TMessage> handler)
        {
            var type = typeof(TMessage);
            if (!_subscribers.ContainsKey(type))
                return;
            _subscribers[type].Remove(handler);
        }

        public void Publish<TMessage>(TMessage message)
        {
            var type = typeof(TMessage);
            if (!_subscribers.ContainsKey(type))
                return;
            foreach (var handler in _subscribers[type])
                ((Action<TMessage>)handler)(message);
        }
    }
}
