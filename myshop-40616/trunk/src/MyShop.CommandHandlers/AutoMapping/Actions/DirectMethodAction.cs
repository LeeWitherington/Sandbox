using System;
using System.Linq;
using System.Reflection;
using MyShop.Commands;
using MyShop.Domain;
using MyShop.Domain.Framework;
using MyShop.Shared;

namespace MyShop.CommandHandlers.AutoMapping.Actions
{
    public class DirectMethodAction : IAutoMappedAction
    {
        private readonly ICommand _command;
        private readonly DirectMethodCommandInfo _info;

        public DirectMethodAction(ICommand command)
        {
            if(command == null) throw new ArgumentNullException("command");

            _command = command;
            _info = DirectMethodCommandInfo.CreateFromDirectMethodCommand(command);
        }

        public void Execute()
        {
            using (var work = new UnitOfWork())
            {
                var config = new AutoMapperConfiguration();
                var targetMethod = GetTargetMethodBasedOnCommandTypeName();
                var repository = MyShopWorld.Instance.DomainRepository;

                var parameterValues = config.GetParameterValues(_command, targetMethod.GetParameters());
                var targetAggregateRoot = repository.GetById(_info.AggregateType, _info.AggregateRootIdValue);

                targetMethod.Invoke(targetAggregateRoot, parameterValues);

                work.Accept();
            }
        }

        private MethodInfo GetTargetMethodBasedOnCommandTypeName()
        {
            var config = new AutoMapperConfiguration();
            var aggregateType = _info.AggregateType;
            var propertiesToMap = config.GetCommandProperties(_command);
            var ctorQuery = from method in aggregateType.GetMethods()
                            where method.Name == _info.MethodName
                            where method.GetParameters().Length == propertiesToMap.Count()
                            where method.GetParameters().For
                            (
                                (value, index) => value.ParameterType.IsAssignableFrom(propertiesToMap.AtIndex(index).PropertyType)
                            )
                            select method;

            if (ctorQuery.Count() == 0)
            {
                var message = String.Format("No method '{0}' found with {1} parameters on aggregate root {2}.",
                                            _info.MethodName, propertiesToMap.Count(), aggregateType.FullName);
                throw new CommandMappingException(message);
            }
            if (ctorQuery.Count() > 1)
            {
                var message = String.Format("Multiple methods '{0}' found with {1} parameters on aggregate root {2}.",
                                            _info.MethodName, propertiesToMap.Count(), aggregateType.FullName);
                throw new CommandMappingException(message);
            }

            return ctorQuery.First();
        }
    }
}