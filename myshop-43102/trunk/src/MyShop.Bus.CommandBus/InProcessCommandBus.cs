using System;
using System.Reflection;
using log4net;
using MyShop.Commands;

namespace MyShop.Bus.CommandBus
{
    /// <summary>
    /// An simple in process command bus.
    /// </summary>
    public class InProcessCommandBus : TransactionalInProcessBus<ICommand>, ICommandBus
    {
        /// <summary>
        /// Gets the log for this type.
        /// </summary>
        /// <value>The log.</value>
        protected override ILog Log
        {
            get { return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); }
        }

        /// <summary>
        /// Called when an message is received.
        /// </summary>
        /// <param name="message">The received message.</param>
        protected override void OnMessageReceived(ICommand message)
        {
            // Log received commands.
            Log.InfoFormat("Command {0} received on InProcessCommandBus.", message.GetType().Name);
        }
    }
}