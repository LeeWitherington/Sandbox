using System;
using MyShop.Domain.Repositories;
using MyShop.Domain.Storage;
using MyShop.Bus.EventBus;
using MyShop.Domain.Framework;

namespace MyShop.Domain
{
    public class MyShopWorld
    {
        private static MyShopWorld _instance;

        public static MyShopWorld Instance
        {
            get
            {
                if(_instance == null)
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
            get; private set;
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

        public DomainRepository DomainRepository
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

    public class WorldNotInitializedException : Exception
    {
    }
}
