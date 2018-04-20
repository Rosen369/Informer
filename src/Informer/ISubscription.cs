using System;
using System.Collections.Generic;
using System.Text;

namespace Informer
{
    public interface ISubToken
    {
        /// <summary>
        /// message token
        /// </summary>
        string Token { get; }
    }

    internal interface ISubscription : ISubToken
    {
        /// <summary>
        /// pulish message
        /// </summary>
        /// <param name="msg">message</param>
        void Publish(Message msg);
    }
}
