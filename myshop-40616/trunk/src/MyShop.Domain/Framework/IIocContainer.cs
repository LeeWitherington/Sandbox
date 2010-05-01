using System;
using System.Collections.Generic;

namespace MyShop.Domain.Framework
{
    public interface IIocContainer
    {
        T GetInstance<T>();
        IEnumerable<T> GetAllInstances<T>();
    }
}
