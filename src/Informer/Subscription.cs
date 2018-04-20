using System;
using System.Collections.Generic;
using System.Text;

namespace Informer
{
    /// <summary>
    /// message subscription
    /// </summary>
    /// <typeparam name="TMessage">type of message</typeparam>
    internal class Subscription<TMessage> : ISubscription where TMessage : Message
    {
        public Subscription(Action<TMessage> action)
        {
            _action = action;
        }

        /// <summary>
        /// subscription token
        /// </summary>
        public string Token
        {
            get
            {
                return _token.ToString();
            }
        }

        /// <summary>
        /// publish 
        /// </summary>
        /// <param name="msg">message</param>
        public void Publish(Message msg)
        {
            if (!(msg is TMessage)) throw new ArgumentException("Message Item is not the correct type.");
            _action(msg as TMessage);
        }

        private readonly Action<TMessage> _action;
        private readonly Guid _token = Guid.NewGuid();
    }
}
