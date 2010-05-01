using System;
using MyShop.Domain.Framework;

namespace MyShop.DomainSpecs.SpecFramework
{
    [Specification]
    public abstract class ValueObjectTestFixture<TValueObject> where TValueObject : ValueObject<TValueObject>
    {
        protected TValueObject ValueObject;
        protected Exception CaughtException;
        protected virtual void Given()
        {
            // Nothing todo.
        }
        protected virtual void Finally() { }
        protected abstract TValueObject When();

        [Given]
        public void Setup()
        {
            CaughtException = null;

            try
            {
                Given();
                ValueObject = When();
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
