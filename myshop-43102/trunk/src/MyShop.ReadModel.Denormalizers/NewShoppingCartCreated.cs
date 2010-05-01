using MyShop.Events.ShoppingCartEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewShoppingCartCreatedHandler : Denormalizer<NewShoppingCartCreated>
    {
        public override void DenormalizeEvent(NewShoppingCartCreated message)
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
    }
}