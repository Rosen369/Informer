using System;
using System.Collections.Generic;
using System.Text;

namespace Informer
{
    /// <summary>
    /// base model of message
    /// </summary>
    public class Message : IMessage
    {
        /// <summary>
        /// time stamp
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// sender of the message can be null
        /// </summary>
        public object Sender { get; private set; }

        public Message() : this(null)
        {
        }

        public Message(object sender)
        {
            this.Sender = sender;
            this.Time = DateTime.Now;
        }
    }
}
