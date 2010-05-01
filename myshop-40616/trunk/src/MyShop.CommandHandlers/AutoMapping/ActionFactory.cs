using System;
using MyShop.CommandHandlers.AutoMapping.Actions;
using MyShop.Shared;
using MyShop.Commands;
using MyShop.Commands.AutoMapping;

namespace MyShop.CommandHandlers.AutoMapping
{
    public class ActionFactory
    {
        public IAutoMappedAction CreateActionForCommand(ICommand command)
        {
            if(command == null) throw new ArgumentNullException("command");

            if (IsCommandMappedToObjectCreation(command))
            {
                return new ObjectCreationAction(command);
            }

            if (IsCommandMappedToADirectMethod(command))
            {
                return new DirectMethodAction(command);
            }

            var message = "No mapping attributes found on {0} command.".FormatIt(command.GetType().Name);
            throw new MappingForCommandNotFoundException(message, command);
        }

        private static Boolean IsCommandMappedToADirectMethod(ICommand command)
        {
            return IsAttributeDefinedOnCommand<MapsToAggregateRootMethodAttribute>(command);
        }

        private static Boolean IsCommandMappedToObjectCreation(ICommand command)
        {
            return IsAttributeDefinedOnCommand<MapsToAggregateRootConstructorAttribute>(command);
        }

        private static Boolean IsAttributeDefinedOnCommand<T>(ICommand command)
        {
            var type = command.GetType();
            var attributes = type.GetCustomAttributes(false);

            foreach(var attrib in attributes)
            {
                if(attrib is T)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
