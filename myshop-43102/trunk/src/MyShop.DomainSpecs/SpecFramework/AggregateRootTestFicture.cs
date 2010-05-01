using System;
using System.Collections.Generic;
using MyShop.Domain.Storage;
using MyShop.Events;

namespace MyShop.DomainSpecs.SpecFramework
{
    [Specification]
    public abstract class AggregateRootTestFixture<TAggregateRoot> where TAggregateRoot : IEventProvider
    {
        protected TAggregateRoot AggregateRoot;
        protected Exception CaughtException;
        protected IEnumerable<IEvent> PublishedEvents;
        protected virtual IEnumerable<HistoricalEvent> Given()
        {
            return new List<HistoricalEvent>();
        }
        protected virtual void Finally() { }
        protected abstract void When();

        [Given]
        public void Setup()
        {
            CaughtException = null;
            AggregateRoot = (TAggregateRoot) Activator.CreateInstance(typeof (TAggregateRoot), new object[] {Given()});

            try
            {
                When();
                PublishedEvents = AggregateRoot.GetChanges();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }
    }
}