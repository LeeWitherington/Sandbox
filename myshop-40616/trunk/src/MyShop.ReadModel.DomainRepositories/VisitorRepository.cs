using System;
using System.Linq;
using MyShop.Domain.NamedQueries;

namespace MyShop.ReadModel.DomainRepositories
{
    public class VisitorRepository : IVisitorNamedQueries
    {
        public bool DoesVisitorExistWithId(Guid id)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                return context.Visitors.Count(v => v.Id == id) > 0;
            }
        }
    }
}
