using System;

namespace MyShop.Domain.NamedQueries
{
    public interface IVisitorNamedQueries
    {
        Boolean DoesVisitorExistWithId(Guid id);
    }
}