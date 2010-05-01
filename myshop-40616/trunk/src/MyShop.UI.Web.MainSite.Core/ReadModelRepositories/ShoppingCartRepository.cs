using System;
using System.Linq;
using MyShop.ReadModel;

namespace MyShop.UI.Web.MainSite.Core.ReadModelRepositories
{
    public class ShoppingCartRepository
    {
        public ShoppingCart FindByVisitorId(Guid visitorId)
        {
            ShoppingCart result = null;

            using (var context = new MyShopReadModelDataContext())
            {
                context.DeferredLoadingEnabled = false;

                var query = from cart in context.ShoppingCarts
                            where cart.VisitorId == visitorId
                            select cart;

                result = query.FirstOrDefault();
            }

            return result;
        }

        public ShoppingCart FindById(Guid id)
        {
            ShoppingCart result;

            using(var context = new MyShopReadModelDataContext())
            {
                result = context.ShoppingCarts.FirstOrDefault(c => c.Id == id);
            }

            return result;
        }

        public void Update(ShoppingCart shoppingCart)
        {
            if(shoppingCart == null) throw new ArgumentNullException("shoppingCart");

            using(var context = new MyShopReadModelDataContext())
            {
                context.ShoppingCarts.Attach(shoppingCart, true);
                context.SubmitChanges();
            }
        }
    }
}
