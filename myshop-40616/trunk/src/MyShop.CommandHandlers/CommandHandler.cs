using MyShop.Bus;
using MyShop.Commands;
using MyShop.Domain.Repositories;
using MyShop.Domain;

namespace MyShop.CommandHandlers
{
    public abstract class CommandHandler<T> : IMessageHandler<T> where T : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler&lt;T&gt;"/> class.
        /// </summary>
        /// <remarks>The <see cref="DomainRepository"/> will be initialized with <see cref="Domain.Repositories.DomainRepository"/>.</remarks>
        protected CommandHandler() : this(MyShopWorld.Instance.DomainRepository)
        {
            // Nothing todo.
        }

        protected CommandHandler(DomainRepository domainRepository)
        {
            DomainRepository = domainRepository;
        }

        public DomainRepository DomainRepository { get; private set; }

        #region IMessageHandler<T> Members

        public abstract void Handle(T message);

        #endregion
    }
}