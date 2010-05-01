using System;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MyShop.Commands;
using MyShop.Commands.ShoppingCartCommands;
using MyShop.ReadModel;
using MyShop.UI.Web.MainSite.Core;
using MyShop.UI.Web.MainSite.Core.ReadModelRepositories;
using MyShop.UI.Web.MainSite.Core.Mvc;
using Ncqrs.Commands;

namespace MyShop.UI.Web.MainSite.Controllers
{
    public class ShoppingCartController : MyShopController
    {
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = GetCartForVisitor();
            return View(cart);
        }

        public ActionResult AddProduct(Product p)
        {
            Guid shoppingCartId;

            var visitorId = new Guid(Request.Cookies["MyShopVisitorIdentifier"].Value);
            var shoppingCart = new ShoppingCartRepository().FindByVisitorId(visitorId);

            if (shoppingCart == null)
            {
                shoppingCartId = Guid.NewGuid();
                var command = new CreateShoppingCartForVisitor(shoppingCartId, visitorId);
                MyShopWebApplication.CommandService.Execute(command);
            }
            else
            {
                shoppingCartId = shoppingCart.Id;
            }

            var addProductCommand = new AddProductToShoppingCart(shoppingCartId, p.Id, 1);
            MyShopWebApplication.CommandService.Execute(addProductCommand);

            return RedirectToAction("Index");
        }

        public ActionResult EditItem(Guid productId)
        {
            var cart = GetCartForVisitor();
            ShoppingCartItem item = cart.ShoppingCartItems.First(i => i.ProductId == productId);

            return View(item);
        }

        [HttpPost]
        public ActionResult EditItem(ShoppingCartItem item)
        {
            var cart = GetCartForVisitor();
            if (cart == null)
            {
                return RedirectToAction("Index");
            }

            ShoppingCartItem inCartItem = cart.ShoppingCartItems.First(i => i.ProductId == item.ProductId);
            if (inCartItem.Quantity != item.Quantity)
            {
                ICommand command;

                if (item.Quantity == 0)
                {
                    command = new RemoveProductFromShoppingCart(cart.Id, item.ProductId);
                }
                else
                {
                    command = new ChangeProductItemQuantityInShoppingCart(cart.Id, item.ProductId, item.Quantity);
                }

                MyShopWebApplication.CommandService.Execute(command);
            }

            return RedirectToAction("Index");
        }

        private ShoppingCart GetCartForVisitor()
        {
            // TODO: Move this to a locator.
            var visitorId = new Guid(Request.Cookies[RegisterVisitAttribute.VisitorIdentifierKey].Value);
            return new ShoppingCartRepository().FindByVisitorId(visitorId);
        }
    }
}