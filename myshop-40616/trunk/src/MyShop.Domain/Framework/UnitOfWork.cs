using System;
using System.Collections.Generic;

namespace MyShop.Domain.Framework
{
    public class UnitOfWork : IDisposable
    {
        [ThreadStatic]
        private static UnitOfWork _threadInstance;

        private readonly Queue<AggregateRoot> _dirtyInstances;

        internal static UnitOfWork Current
        {
            get
            {
                return _threadInstance;
            }
        }

        public UnitOfWork()
        {
            if (Current != null)
                throw new InvalidOperationException("An other UnitOfWork instance already exists in this context.");

            _dirtyInstances = new Queue<AggregateRoot>();
            _threadInstance = this;
        }

        internal void RegisterDirty(AggregateRoot dirtyInstance)
        {
            if (!_dirtyInstances.Contains(dirtyInstance))
            {
                _dirtyInstances.Enqueue(dirtyInstance);
            }
        }

        public void Accept()
        {
            var repository = MyShopWorld.Instance.DomainRepository;

            while(_dirtyInstances.Count > 0)
            {
                var dirtyInstance = _dirtyInstances.Dequeue();
                repository.Save(dirtyInstance);
            }
        }

        public void Dispose()
        {
            _threadInstance = null;
        }
    }
}