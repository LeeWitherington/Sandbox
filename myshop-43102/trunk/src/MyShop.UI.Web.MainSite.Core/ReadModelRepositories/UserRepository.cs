using System;
using System.Linq;
using MyShop.ReadModel;

namespace MyShop.UI.Web.MainSite.Core.ReadModelRepositories
{
    public class UserRepository
    {
        public User FindById(Guid id)
        {
            User result;

            using (var context = new MyShopReadModelDataContext())
            {
                var query = from u in context.Users
                            where u.Id == id
                            select u;

                result = query.FirstOrDefault();
            }

            return result;
        }
    }
}
