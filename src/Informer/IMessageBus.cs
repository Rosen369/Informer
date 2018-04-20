using System;
using System.Threading.Tasks;

namespace Informer
{
    /// <summary>
    /// message bus contract
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// emit message
        /// </summary>
        /// <typeparam name="TMessage">type of message</typeparam>
        /// <param name="msg">message</param>
        void Emit<TMessage>(TMessage msg) where TMessage : Message;

        /// <summary>
        /// emit message async
        /// </summary>
        /// <typeparam name="TMessage">type of message</typeparam>
        /// <param name="msg">message</param>
        /// <returns>task of emit</returns>
        Task EmitAsync<TMessage>(TMessage msg) where TMessage : Message;

        /// <summary>
        /// subscribe message
        /// </summary>
        /// <typeparam name="TMessage">type of message</typeparam>
        /// <param name="action">action to handle message</param>
        /// <returns>subscription</returns>
        ISubToken Subscribe<TMessage>(Action<TMessage> action) where TMessage : Message;

        /// <summary>
        /// unsubscribe message by subscription
        /// </summary>
        /// <typeparam name="TMessage">type of message</typeparam>
        /// <param name="subscription">subscription</param>
        void Unsubscribe<TMessage>(ISubToken subscription) where TMessage : Message;

        /// <summary>
        /// unsubscribe message by subscription(uncleared message type inefficiency)
        /// </summary>
        /// <param name="subscription">subscription</param>
        void Unsubscribe(ISubToken subscription);

        /// <summary>
        /// unsubscribe message by token
        /// </summary>
        /// <typeparam name="TMessage">type of message</typeparam>
        /// <param name="token">token</param>
        void Unsubscribe<TMessage>(string token) where TMessage : Message;

        /// <summary>
        /// unsubscribe message by token(uncleared message type inefficiency)
        /// </summary>
        /// <param name="token">token</param>
        void Unsubscribe(string token);
    }
}
