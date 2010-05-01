using MyShop.Commands;

namespace MyShop.Bus.CommandBus
{
    public interface ICommandBus : IBus<ICommand>
    {
    }
}