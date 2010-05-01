using MyShop.Events.ShoppingCartEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductAddedToShoppingCartHandler : Denormalizer<ProductAddedToShoppingCart>
    {
        public override void DenormalizeEvent(ProductAddedToShoppingCart message)
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
    }
}