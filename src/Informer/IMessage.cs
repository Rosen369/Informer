using System;
using System.Collections.Generic;
using System.Text;

namespace Informer
{
    public interface IMessage
    {
        /// <summary>
        /// message sender (could be null)
        /// </summary>
        object Sender { get; }

        /// <summary>
        /// time stamp on message send
        /// </summary>
        DateTime Time { get; }
    }
}
