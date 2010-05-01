using System;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using log4net;
using log4net.Config;
using StructureMap;
using MyShop.Domain;
using MyShop.Commands.UserCommands;
using Ncqrs.CommandHandling;
using Ncqrs.Domain;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Bus;
using MyShop.Domain.NamedQueries;
using Ncqrs.Eventing.Storage.SQL;
using MyShop.ReadModel.Properties;
using System.Configuration;
using Ncqrs.CommandHandling.AutoMapping;
using MyShop.Commands.ProductCommands;
using MyShop.Commands.ShoppingCartCommands;
using MyShop.Commands.VisitorCommands;
using Ncqrs.Domain.Storage;
using MyShop.ReadModel.Denormalizers;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.UI.Web.MainSite.Core
{
    public class MyShopWebApplication : HttpApplication
    {
        private class RedirectingIocContainerForStructureMap : IIocContainer
        {
            public T GetInstance<T>()
            {
                return ObjectFactory.GetInstance<T>();
            }

            public IEnumerable<T> GetAllInstances<T>()
            {
                return ObjectFactory.GetAllInstances<T>();
            }
        }

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ICommandService CommandService { get
        {
            return ObjectFactory.GetInstance<ICommandService>();
        }}

        public override void Init()
        {
            // Configure 
            XmlConfigurator.Configure();
            

            ObjectFactory.Initialize(locator =>
                                         {
                                             locator.ForRequestedType<IAggregateRootLoader>().TheDefaultIsConcreteType<DefaultAggregateRootLoader>().AsSingletons();
                                             locator.ForRequestedType<IDomainRepository>().TheDefaultIsConcreteType
                                                 <DomainRepository>().AsSingletons();
                                             locator.ForRequestedType<IEventStore>().TheDefault.IsThis(new SimpleMicrosoftSqlServerEventStore(System.Configuration.ConfigurationManager.ConnectionStrings["MyShop.EventStorage.Properties.Settings.MyShopEventsConnectionString"].ConnectionString));
                                             //locator.ForRequestedType<IEventStore>().TheDefault.IsThis(new MongoDBEventStore(new Mongo()));
                                             locator.ForRequestedType<IEventBus>().TheDefaultIsConcreteType
                                                 <InProcessEventBus>().AsSingletons();
                                             locator.ForRequestedType<ICommandService>().TheDefaultIsConcreteType
                                                 <TransactionalInProcessCommandService>().AsSingletons();
                                         });

            MyShopWorld.Initialize(new RedirectingIocContainerForStructureMap());

            RegisterHandlers(ObjectFactory.GetInstance<ICommandService>(), ObjectFactory.GetInstance<IDomainRepository>());
            RegisterEventHandlers(ObjectFactory.GetInstance<IEventBus>());

            Log.Info("Application started.");
        }

        private static void RegisterHandlers(ICommandService service, IDomainRepository repository)
        {
            // TODO: Remove repository dependency. It is still avail via UnitOfWork context.
            service.RegisterHandler<AddNewProduct>(new AutoMappingCommandHandler<AddNewProduct>(repository));
            service.RegisterHandler<AddProductToShoppingCart>(new AutoMappingCommandHandler<AddProductToShoppingCart>(repository));
            service.RegisterHandler<ChangeProductImage>(new AutoMappingCommandHandler<ChangeProductImage>(repository));
            service.RegisterHandler<RemoveProductFromShoppingCart>(new AutoMappingCommandHandler<RemoveProductFromShoppingCart>(repository));
            service.RegisterHandler<UpdateGeneralProductInformation>(new AutoMappingCommandHandler<UpdateGeneralProductInformation>(repository));
            service.RegisterHandler<UpdateUnitPriceOfProduct>(new AutoMappingCommandHandler<UpdateUnitPriceOfProduct>(repository));
            service.RegisterHandler<UpdateUnitsInStockOfProduct>(new AutoMappingCommandHandler<UpdateUnitsInStockOfProduct>(repository));
            service.RegisterHandler<ChangeProductItemQuantityInShoppingCart>(new AutoMappingCommandHandler<ChangeProductItemQuantityInShoppingCart>(repository));
            service.RegisterHandler<AssignRoleToUser>(new AutoMappingCommandHandler<AssignRoleToUser>(repository));
            service.RegisterHandler<RemoveRoleFromUser>(new AutoMappingCommandHandler<RemoveRoleFromUser>(repository));
            service.RegisterHandler<AddNewVisitor>(new AutoMappingCommandHandler<AddNewVisitor>(repository));
            service.RegisterHandler<RegisterVisit>(new AutoMappingCommandHandler<RegisterVisit>(repository));
            service.RegisterHandler<CreateShoppingCartForVisitor>(new AutoMappingCommandHandler<CreateShoppingCartForVisitor>(repository));
            service.RegisterHandler<RegisterNewUser>(new AutoMappingCommandHandler<RegisterNewUser>(repository));
        }

        private static void RegisterEventHandlers(IEventBus bus)
        {
            foreach (var denormalizerType in typeof(GeneralProductInformationUpdatedHandler).Assembly.GetTypes())
            {
                if (IsSubclassOfRawGeneric(typeof(Denormalizer<>), denormalizerType))
                {
                    var instance = Activator.CreateInstance(denormalizerType);

                    bus.RegisterHandler(denormalizerType.BaseType.GetGenericArguments()[0], (IEventHandler)instance);
                }
                
            }
        }

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}