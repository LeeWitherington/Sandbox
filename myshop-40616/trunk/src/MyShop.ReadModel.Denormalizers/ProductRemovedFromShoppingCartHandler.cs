using System.Linq;
using MyShop.Bus;
using MyShop.Events.ShoppingCartEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductRemovedFromShoppingCartHandler : IMessageHandler<ProductRemovedFromShoppingCart>
    {
        #region IMessageHandler<ProductRemovedFromShoppingCart> Members

        public void Handle(ProductRemovedFromShoppingCart message)
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

        #endregion
    }
}