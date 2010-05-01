using System;

namespace MyShop.Domain.Framework.DomainEventMapping
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AutoMapDomainEventsBasedOnMethodNamesAttribute : Attribute
    {
    }
}
