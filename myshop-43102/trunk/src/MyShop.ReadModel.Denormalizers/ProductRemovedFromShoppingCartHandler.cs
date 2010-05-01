using System.Linq;
using MyShop.Events.ShoppingCartEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductRemovedFromShoppingCartHandler : Denormalizer<ProductRemovedFromShoppingCart>
    {
        public override void DenormalizeEvent(ProductRemovedFromShoppingCart message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                ShoppingCartItem item = (from i in context.ShoppingCartItems
                                         where
                                             i.ShoppingCartId == message.ShoppingCartId &&
                                             i.ProductId == message.ProductId
                                         select i).First();

                context.ShoppingCartItems.DeleteOnSubmit(item);
                context.SubmitChanges();
            }
        }
    }
}