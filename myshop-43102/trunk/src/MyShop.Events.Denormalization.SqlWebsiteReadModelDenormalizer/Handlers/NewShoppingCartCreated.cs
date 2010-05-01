using System;
using MyShop.Bus;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class NewShoppingCartCreatedHandler : IMessageHandler<NewShoppingCartCreated>
    {
        public void Handle(NewShoppingCartCreated message)
        {
            using (var context = new WebSiteReadModelDataContext())
            {
                // Create new cart.
                var cart = new ShoppingCart();
                cart.Id = message.ShoppingCartId;
                cart.UserId = message.UserId;

                // Put the cart in the unit of work list.
                context.ShoppingCarts.InsertOnSubmit(cart);

                // Submit changes.
                context.SubmitChanges();
            }
        }
    }
}
