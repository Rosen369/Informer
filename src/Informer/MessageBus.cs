using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informer
{
    /// <summary>
    /// message bus
    /// </summary>
    public class MessageBus : IMessageBus
    {
        private MessageBus()
        {
            _subscriptions = new Dictionary<Type, IDictionary<string, ISubscription>>();
        }

        private class Nested
        {
            internal static readonly MessageBus Instance = new MessageBus();
        }

        public static MessageBus GetInstance()
        {
            return Nested.Instance;
        }

        public void Emit<TMessage>(TMessage msg) where TMessage : Message
        {
            Publish(msg);
        }

        public Task EmitAsync<TMessage>(TMessage msg) where TMessage : Message
        {
            return Task.Run(delegate
            {
                Publish(msg);
            });
        }

        public ISubToken Subscribe<TMessage>(Action<TMessage> action) where TMessage : Message
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            lock (Lock)
            {
                if (!_subscriptions.ContainsKey(typeof(TMessage)))
                {
                    _subscriptions.Add(typeof(TMessage), new Dictionary<string, ISubscription>());
                }
                var subscription = new Subscription<TMessage>(action);
                _subscriptions[typeof(TMessage)].Add(subscription.Token, subscription);
                return subscription;
            }
        }

        public void Unsubscribe<TMessage>(ISubToken subscription) where TMessage : Message
        {
            Unsubscribe<TMessage>(subscription.Token);
        }

        public void Unsubscribe(ISubToken subscription)
        {
            Unsubscribe(subscription.Token);
        }

        public void Unsubscribe<TMessage>(string token) where TMessage : Message
        {
            lock (Lock)
            {
                if (!_subscriptions.ContainsKey(typeof(TMessage)))
                {
                    return;
                }
                var typeContainer = _subscriptions[typeof(TMessage)];
                if (typeContainer.ContainsKey(token))
                {
                    typeContainer.Remove(token);
                }
            }
        }

        public void Unsubscribe(string token)
        {
            lock (Lock)
            {
                foreach (var typeContainer in _subscriptions.Values)
                {
                    if (typeContainer.ContainsKey(token))
                    {
                        typeContainer.Remove(token);
                    }
                }
            }
        }

        private void Publish<TMessage>(TMessage msg) where TMessage : Message
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            IList<ISubscription> subscriptionList = null;
            lock (Lock)
            {
                if (_subscriptions.ContainsKey(typeof(TMessage)))
                {
                    subscriptionList = _subscriptions[typeof(TMessage)].Values.ToList();
                }
            }
            foreach (var subscription in subscriptionList)
            {
                subscription.Publish(msg);
            }
        }

        private readonly IDictionary<Type, IDictionary<string, ISubscription>> _subscriptions;
        private static readonly object Lock = new object();
    }
}
