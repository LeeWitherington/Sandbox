﻿using System.Linq;
using Fohjin.EventStore;
using Fohjin.EventStore.Configuration;
using Fohjin.EventStore.Infrastructure;

namespace Test.Fohjin.EventStore.Infrastructure
{
    public class When_an_event_gets_published : BaseTestFixture
    {
        private TestClient _testClient;

        protected override void Given()
        {
            var eventProcessorCache = PreProcessorHelper.CreateEventProcessorCache();
            _testClient = new DomainRepository(new AggregateRootFactory(eventProcessorCache, new ApprovedEntitiesCache())).CreateNew<TestClient>();
        }

        protected override void When()
        {
            _testClient.ClientMoves(new Address("street", "number", "postalCode", "city"));
        }

        [Then]
        public void Then_the_internal_collection_of_events_will_contain_the_published_event()
        {
            var eventProvider = (IEventProvider) _testClient;
            eventProvider.GetChanges().Count().WillBe(1);
            eventProvider.GetChanges().First().WillBeOfType<ClientMovedEvent>();
        }
    }
}