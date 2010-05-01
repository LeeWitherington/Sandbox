using MyShop.Events;

namespace MyShop.Bus.EventBus
{
    public interface IEventBus : IBus<IEvent>
    {
    }
}