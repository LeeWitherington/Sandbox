using System;
using System.Linq;
using System.Reflection;
using MyShop.Commands;
using MyShop.Domain.Framework;
using MyShop.Shared;

namespace MyShop.CommandHandlers.AutoMapping.Actions
{
    public class ObjectCreationAction : IAutoMappedAction
    {
        private readonly ICommand _command;
        private readonly ObjectCreationCommandInfo _commandInfo;

        public ObjectCreationAction(ICommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            _command = command;
            _commandInfo = ObjectCreationCommandInfo.CreateFromDirectMethodCommand(command);
        }

        public void Execute()
        {
            using (var work = new UnitOfWork())
            {
                var config = new AutoMapperConfiguration();
                var targetCtor = GetConstructorBasedOnCommand();

                var parameterValues = config.GetParameterValues(_command, targetCtor.GetParameters());
                targetCtor.Invoke(parameterValues);

                work.Accept();
            }
        }

        private ConstructorInfo GetConstructorBasedOnCommand()
        {
            var config = new AutoMapperConfiguration();
            var aggregateType = _commandInfo.AggregateType;
            var propertiesToMap = config.GetCommandProperties(_command);
            var ctorQuery = from ctor in aggregateType.GetConstructors()
                            where ctor.GetParameters().Length == propertiesToMap.Count()
                            && ctor.GetParameters().For
                            (
                                (value, index) => value.ParameterType.IsAssignableFrom(propertiesToMap.AtIndex(index).PropertyType)
                            )
                            select ctor;

            if (ctorQuery.Count() == 0)
            {
                var message = String.Format("No constructor found with {0} parameters on aggregate root {1}.",
                                            propertiesToMap.Count(), aggregateType.FullName);
                throw new CommandMappingException(message);
            }
            if (ctorQuery.Count() > 1)
            {
                var message = String.Format("Multiple constructors found with {0} parameters on aggregate root {1}.",
                                            propertiesToMap.Count(), aggregateType.FullName);
                throw new CommandMappingException(message);
            }

            return ctorQuery.First();
        }
    }
}