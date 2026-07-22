using System;
using System.Collections.Generic;

namespace Enemy
{
    public class SignalBus
    {
        private Dictionary<Type, object> subscribers = new Dictionary<Type, object>();

        public void Subscribe<T>(Action<T> callback)
        {
            Type type = typeof(T);
            
            if (!subscribers.ContainsKey(type))
            {
                subscribers[type] = new Action<T>(delegate { });
            }

            subscribers[type] = (Action<T>)subscribers[type] + callback;
        }

        public void Fire<T>(T signal)
        {
            Type type = typeof(T);
            
            if (subscribers.ContainsKey(type))
            {
                ((Action<T>)subscribers[type])?.Invoke(signal);
            }
        }
    }
}