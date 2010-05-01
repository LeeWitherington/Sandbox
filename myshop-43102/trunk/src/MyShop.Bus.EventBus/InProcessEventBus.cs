using System.Reflection;
using log4net;
using MyShop.Events;
using MyShop.ReadModel.Denormalizers;
using System.Text;

namespace MyShop.Bus.EventBus
{
    /// <summary>
    /// An simple in process command bus.
    /// </summary>
    public class InProcessEventBus : TransactionalInProcessBus<IEvent>, IEventBus
    {
        /// <summary>
        /// Gets the log for this type.
        /// </summary>
        /// <value>The log.</value>
        protected override ILog Log
        {
            get { return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); }
        }

        protected ILog EventLog
        {
            get
            {
                return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ".Events");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InProcessEventBus"/> class.
        /// </summary>
        public InProcessEventBus()
        {
            // Register all event handlers.
            RegisterHandler(new GeneralProductInformationUpdatedHandler());
            RegisterHandler(new ProductAddedToShoppingCartHandler());
            RegisterHandler(new NewProductCreatedHandler());
            RegisterHandler(new NewShoppingCartCreatedHandler());
            RegisterHandler(new NewUserCreatedHandler());
            RegisterHandler(new ProductImageChangedHandler());
            RegisterHandler(new ProductQuantityInShoppingCartChangedHandler());
            RegisterHandler(new ProductStockInformationUpdatedHandler());
            RegisterHandler(new ProductUnitPriceChangedHandler());
            RegisterHandler(new ProductRemovedFromShoppingCartHandler());
            RegisterHandler(new RoleAssignedToUserHandler());
            RegisterHandler(new RoleRemovedFromUserHandler());
            RegisterHandler(new NewVisitorCreatedHandler());
            RegisterHandler(new VisitorVisitedHandler());
        }

        /// <summary>
        /// Called when an message is received.
        /// </summary>
        /// <param name="message">The received message.</param>
        protected override void OnMessageReceived(IEvent message)
        {
            var messageType = message.GetType();

            var builder = new StringBuilder();
            builder.AppendFormat("Event {0} received in InProcessEventBus (", messageType.Name);

            if (Log.IsDebugEnabled)
            {
                foreach (var property in messageType.GetProperties())
                {
                    if (property.GetIndexParameters().Length == 0)
                    {
                        builder.AppendFormat("\t{0}={1}", property.Name, property.GetValue(message, null));
                    }
                }

                builder.Append(").");
            }

            // Log received event.
            EventLog.Info(builder);
        }
    }
}