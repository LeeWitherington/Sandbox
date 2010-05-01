using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using MyShop.Events;
using System.Text.RegularExpressions;

namespace MyShop.Domain.Framework.DomainEventMapping
{
    public class MethodNameConventionEventHandlerFactory : IDomainEventHandlerFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Regex _eventNameRegex = new Regex("(?<EventName>^.*)(EventHandler$)");

        protected IEnumerable<Type> AllEvents
        {
            get
            {
                Assembly eventAssembly = typeof (IEvent).Assembly;

                foreach(var eventType in eventAssembly.GetTypes().Where((t) => (t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IEvent)))))
                {
                    yield return eventType;
                }
            }
        }

        public IEnumerable<DomainEventHandler> CreateHandlersForAggregateRoot(AggregateRoot aggregateRoot)
        {
            if(!AggregateRootIsMarkedForAutoMappingBasedOnMethodNames(aggregateRoot))
            {
                yield break;
            }

            // Get only non public instance methods as candidates.
            var type = aggregateRoot.GetType();
            var candidateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            
            foreach(var method in candidateMethods)
            {
                if (!MethodDoesMatchWithTheNamingPattern(method))
                {
                    Log.DebugFormat("Skipped method {0}, since it does not match the naming pattern.", method.Name);
                    continue;
                }

                if(!MethodDoesOnlyHasOneParameter(method))
                {
                    Log.DebugFormat("Skipped method {0}, since it has multiple parameters.", method.Name);
                    continue;
                }

                if(!MethodParameterDoesImplementTheIEventInterface(method))
                {
                    Log.DebugFormat("Skipped method {0}, since the first parameter could not be assigned to a IEvent variable.");
                    continue;
                }

                var eventName = GetEventNameFromMethod(method);
                var eventTypes = GetEventTypesBasedOnEventName(eventName);

                if(eventTypes.Count() == 0)
                {
                    Log.WarnFormat("Could not find an event with the name {0}. Method {1} is ignored as domain event handler.", eventName, method.Name);
                    continue;
                }
                if(eventTypes.Count() > 1)
                {
                    Log.WarnFormat("Found multiple event with the name {0}. Method {1} is ignored as domain event handler.",
                        eventName, method.Name);
                    continue;
                }

                Log.Info("Found method {0} ");

                var eventType = eventTypes.First();
                // Create method copy, since this variable will
                // have a different value at the next iteration.
                var methodCopy = method;
                DomainEventHandler<IEvent> handler = (e) => methodCopy.Invoke(aggregateRoot, new object[] {e});
                
                yield return new DomainEventHandler(eventType, handler);
            }
        }

        private static Boolean AggregateRootIsMarkedForAutoMappingBasedOnMethodNames(AggregateRoot root)
        {
            var type = root.GetType();
            return type.GetCustomAttributes(typeof (AutoMapDomainEventsBasedOnMethodNamesAttribute), false).Count() > 0;
        }

        private IEnumerable<Type> GetEventTypesBasedOnEventName(String  eventName)
        {
            return AllEvents.Where(t => t.Name.Equals(eventName));
        }

        private static String GetEventNameFromMethod(MethodInfo method)
        {
            Match match = _eventNameRegex.Match(method.Name);
            return match.Groups["EventName"].Value;
        }

        private static Boolean MethodParameterDoesImplementTheIEventInterface(MethodInfo method)
        {
            return typeof (IEvent).IsAssignableFrom(method.GetParameters().First().ParameterType);
        }

        private static Boolean MethodDoesOnlyHasOneParameter(MethodInfo method)
        {
            return method.GetParameters().Count() == 1;
        }

        private static Boolean MethodDoesMatchWithTheNamingPattern(MethodInfo method)
        {
            return _eventNameRegex.IsMatch(method.Name);
        }
    }
}
