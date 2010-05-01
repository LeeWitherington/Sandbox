using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Domain
{
    public interface IIocContainer
    {
        T GetInstance<T>();
        IEnumerable<T> GetAllInstances<T>();
    }
}
