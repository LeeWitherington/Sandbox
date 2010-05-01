using System.Linq;
using MyShop.Bus;
using MyShop.Events.ProductEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductStockInformationUpdatedHandler : IMessageHandler<ProductStockInformationUpdated>
    {
        #region IMessageHandler<ProductStockInformationUpdated> Members

        public void Handle(ProductStockInformationUpdated message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.UnitsInStock = message.UnitsInStock.HasValue ? message.UnitsInStock.Value : 0;
                context.SubmitChanges();
            }
        }

        #endregion
    }
}