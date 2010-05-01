using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using log4net;
using log4net.Config;
using MyShop.Bus.CommandBus;
using MyShop.Bus.EventBus;
using MyShop.CommandHandlers;
using MyShop.Domain.NamedQueries;
using MyShop.Domain.Repositories;
using MyShop.EventStorage;
using MyShop.Domain.Framework;
using MyShop.ReadModel.DomainRepositories;
using StructureMap;
using MyShop.Domain;
using MyShop.Commands.UserCommands;
using MyShop.Domain.Storage;
using MyShop.Domain.Framework.DomainEventMapping;

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

        public static ICommandBus CommandBus { get
        {
            return ObjectFactory.GetInstance<ICommandBus>();
        }}

        public override void Init()
        {
            // Configure 
            XmlConfigurator.Configure();
            

            ObjectFactory.Initialize(locator =>
                                         {
                                             locator.ForRequestedType<DomainRepository>().TheDefaultIsConcreteType
                                                 <DomainRepository>().AsSingletons();
                                             locator.ForRequestedType<IEventStore>().TheDefaultIsConcreteType
                                                 <SqlEventStore>().AsSingletons();
                                             locator.ForRequestedType<IEventBus>().TheDefaultIsConcreteType
                                                 <InProcessEventBus>().AsSingletons();
                                             locator.ForRequestedType<ICommandBus>().TheDefaultIsConcreteType
                                                 <InProcessCommandBus>().AsSingletons();
                                             locator.ForRequestedType<IVisitorNamedQueries>().TheDefaultIsConcreteType
                                                 <VisitorRepository>();
                                             locator.ForRequestedType<IUserMembershipNamedQueries>().
                                                 TheDefaultIsConcreteType<UserMembershipNamedQueries>();
                                             locator.ForRequestedType<IDomainEventHandlerFactory>().AddConcreteType
                                                 <AttributeBasedEventHandlerCreator>();
                                             locator.ForRequestedType<IDomainEventHandlerFactory>().AddConcreteType
                                                 <MethodNameConventionEventHandlerFactory>();
                                         });

            MyShopWorld.Initialize(new RedirectingIocContainerForStructureMap());
            new MyShopCommandHandlerRegister().RegisterHandlers(CommandBus);

            Log.Info("Application started.");
        }
    }
}