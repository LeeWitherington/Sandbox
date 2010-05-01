using System;

namespace MyShop.Domain.Framework
{
    public class HandlerForEventTypeAlreadyRegisteredException : Exception
    {
        public HandlerForEventTypeAlreadyRegisteredException(Type eventType)
        {
            EventType = eventType;
        }

        public Type EventType { get; private set; }
    }
}