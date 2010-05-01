using System.Linq;
using MyShop.Bus;
using MyShop.Events.ProductEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductUnitPriceChangedHandler : IMessageHandler<ProductUnitPriceChanged>
    {
        #region IMessageHandler<ProductUnitPriceChanged> Members

        public void Handle(ProductUnitPriceChanged message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.UnitPrice = message.UnitPrice;
                context.SubmitChanges();
            }
        }

        #endregion
    }
}