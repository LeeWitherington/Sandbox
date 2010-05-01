using MyShop.Bus;
using MyShop.Events.ShoppingCartEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductAddedToShoppingCartHandler : IMessageHandler<ProductAddedToShoppingCart>
    {
        #region IMessageHandler<ProductAddedToShoppingCart> Members

        public void Handle(ProductAddedToShoppingCart message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var item = new ShoppingCartItem();
                item.ShoppingCartId = message.ShoppingCartId;
                item.ProductId = message.ProductId;
                item.Quantity = message.Quantity;

                context.ShoppingCartItems.InsertOnSubmit(item);
                context.SubmitChanges();
            }
        }

        #endregion
    }
}