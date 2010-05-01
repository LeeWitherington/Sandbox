using MyShop.Bus;
using MyShop.Events.ShoppingCartEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewShoppingCartCreatedHandler : IMessageHandler<NewShoppingCartCreated>
    {
        #region IMessageHandler<NewShoppingCartCreated> Members

        public void Handle(NewShoppingCartCreated message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                // Create new cart.
                var cart = new ShoppingCart();
                cart.Id = message.ShoppingCartId;
                cart.VisitorId = message.VisitorId;

                // Put the cart in the unit of work list.
                context.ShoppingCarts.InsertOnSubmit(cart);

                // Submit changes.
                context.SubmitChanges();
            }
        }

        #endregion
    }
}