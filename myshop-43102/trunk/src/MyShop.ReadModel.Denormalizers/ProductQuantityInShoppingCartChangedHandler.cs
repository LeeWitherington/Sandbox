using System.Linq;
using MyShop.Events.ShoppingCartEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductQuantityInShoppingCartChangedHandler : Denormalizer<ProductQuantityInShoppingCartChanged>
    {
        public override void DenormalizeEvent(ProductQuantityInShoppingCartChanged message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                ShoppingCartItem cartItem = (from item in context.ShoppingCartItems
                                             where item.ShoppingCartId == message.ShoppingCartId &&
                                                   item.ProductId == message.ProductId
                                             select item).First();
                cartItem.Quantity = message.NewQuantity;
                context.SubmitChanges();
            }
        }
    }
}