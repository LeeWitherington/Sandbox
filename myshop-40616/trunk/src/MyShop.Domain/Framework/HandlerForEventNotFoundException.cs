using System;

namespace MyShop.Domain.Framework
{
    public class HandlerForEventNotFoundException : Exception
    {
        public HandlerForEventNotFoundException(Type eventType)
        {
            EventType = eventType;
        }

        public Type EventType { get; private set; }
    }
}