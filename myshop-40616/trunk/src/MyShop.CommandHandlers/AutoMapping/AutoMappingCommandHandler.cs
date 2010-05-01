using System;
using MyShop.Commands;

namespace MyShop.CommandHandlers.AutoMapping
{
    public class AutoMappingCommandHandler<T> : CommandHandler<T> where T : ICommand
    {
        public String OverridenCommandName
        {
            get; private set;
        }

        public AutoMappingCommandHandler()
        {
            
        }

        public AutoMappingCommandHandler(String overridenCommandName)
        {
            OverridenCommandName = overridenCommandName;
        }

        public override void Handle(T command)
        {
            var factory = new ActionFactory();
            var action = factory.CreateActionForCommand(command);
            action.Execute();
        }
    }
}
