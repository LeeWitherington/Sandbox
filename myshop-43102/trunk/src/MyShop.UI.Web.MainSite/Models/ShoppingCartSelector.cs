using System;
using System.Web;
using MyShop.ReadModel;

namespace MyShop.UI.Web.MainSite.Models
{
    // TODO: REMOVE!
    public class ShoppingCartSelector
    {
        private HttpContextBase _context;

        public ShoppingCartSelector(HttpContextBase context)
        {
            if(context != null) throw new ArgumentNullException("context");

            _context = context;
        }
    }
}
