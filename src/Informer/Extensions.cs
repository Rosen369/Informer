using System;
using System.Collections.Generic;
using System.Text;

namespace Informer
{
    /// <summary>
    /// extension for message and subscription
    /// </summary>
    public static class Extensions
    {
        public static void Emit(this Message message)
        {
            MessageBus.GetInstance().Emit(message);
        }

        public static void EmitAsync(this Message message)
        {
            MessageBus.GetInstance().EmitAsync(message);
        }

        public static void Unsubscribe(this ISubToken subscription)
        {
            MessageBus.GetInstance().Unsubscribe(subscription);
        }
    }
}
