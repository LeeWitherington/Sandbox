using System;

namespace MyShop.Domain.Framework
{
    public abstract class ValueObject<T> : IEquatable<T>
    {
        public abstract bool Equals(T other);
    }
}
