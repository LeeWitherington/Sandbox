using System.Linq;
using MyShop.Bus;
using MyShop.Events.ShoppingCartEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductQuantityInShoppingCartChangedHandler : IMessageHandler<ProductQuantityInShoppingCartChanged>
    {
        #region IMessageHandler<ProductQuantityInShoppingCartChanged> Members

        public void Handle(ProductQuantityInShoppingCartChanged message)
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

        #endregion
    }
}