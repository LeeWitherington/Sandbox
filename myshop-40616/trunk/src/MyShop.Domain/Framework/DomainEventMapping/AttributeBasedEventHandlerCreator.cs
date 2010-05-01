using System;
using System.Reflection;
using MyShop.Events;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Domain.Framework.DomainEventMapping
{
    public class AttributeBasedEventHandlerCreator : IDomainEventHandlerFactory
    {
        public IEnumerable<DomainEventHandler> CreateHandlersForAggregateRoot(AggregateRoot aggregateRoot)
        {
            if(aggregateRoot == null) throw new ArgumentNullException("aggregateRoot");

            var aggregateRootType = aggregateRoot.GetType();
            foreach (var method in aggregateRootType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                foreach (HandlesEventAttribute handlesAttribute in method.GetCustomAttributes(typeof(HandlesEventAttribute), false))
                {
                    if (method.IsStatic) // Handlers are never static. Since they need to update the internal state of an aggregate root.
                    {
                        // TODO: Throw exception.
                        throw new InvalidOperationException();
                    }
                    if (method.GetParameters().Count() != 1) // The method should only have one parameter.
                    {
                        // TODO: Throw exception.
                        throw new InvalidOperationException();
                    }
                    if (!typeof(IEvent).IsAssignableFrom(method.GetParameters().First().ParameterType)) // The parameter should be an IEvent.
                    {
                        // TODO: Throw exception.
                        throw new InvalidOperationException();
                    }
                    if (method.GetParameters().First().ParameterType != handlesAttribute.EventType) // The parameter should be the same as specified by the attribute.
                    {
                        // TODO: Throw exception.
                        throw new InvalidOperationException();
                    }

                    // A method copy is needed because
                    // the method variable itself will change
                    // in the next iteration.
                    MethodInfo methodCopy = method;
                    var handler = new DomainEventHandler(handlesAttribute.EventType, (e) => methodCopy.Invoke(aggregateRoot, new object[] {e}));

                    yield return handler;
                }
            }
        }
    }
}