using System;
using MyShop.Bus;

namespace MyShop.Events
{
    /// <summary>
    /// Represents an event.
    /// </summary>
    /// <remarks>All events should be immutable and serializable.</remarks>
    public interface IEvent : IMessage
    {
    }
}