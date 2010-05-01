using System;
using Ncqrs.Domain.Storage;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Bus;
using Ncqrs.Domain;

namespace MyShop.Domain
{
    public class MyShopWorld
    {
        private static MyShopWorld _instance;

        public static MyShopWorld Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new WorldNotInitializedException();
                }

                return _instance;
            }
        }

        public static void Initialize(IIocContainer container)
        {
            _instance = new MyShopWorld(container);
        }

        private MyShopWorld(IIocContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            IocContainer = container;
        }

        internal IIocContainer IocContainer
        {
            get;
            private set;
        }

        internal IEventStore EventStore
        {
            get
            {
                return IocContainer.GetInstance<IEventStore>();
            }
        }
        internal IEventBus EventBus
        {
            get
            {
                return IocContainer.GetInstance<IEventBus>();
            }
        }

        public IDomainRepository DomainRepository
        {
            get { return new DomainRepository(EventStore, EventBus); }
        }

        public Guid GetGlobalUniqueIdentifier()
        {
            return Guid.NewGuid();
        }

        public DateTime GetCurrentDateAndTime()
        {
            return DateTime.UtcNow;
        }
    }

    [Serializable]
    public class WorldNotInitializedException : Exception
    {
        public WorldNotInitializedException() { }
        public WorldNotInitializedException(string message) : base(message) { }
        public WorldNotInitializedException(string message, Exception inner) : base(message, inner) { }
        protected WorldNotInitializedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
