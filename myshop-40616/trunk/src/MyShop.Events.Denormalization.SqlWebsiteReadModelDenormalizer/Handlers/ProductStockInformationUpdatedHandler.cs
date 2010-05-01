using System;
using System.Linq;
using MyShop.Bus;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class ProductStockInformationUpdatedHandler : IMessageHandler<ProductStockInformationUpdated>
    {
        public void Handle(ProductStockInformationUpdated message)
        {
            using (var context = new WebSiteReadModelDataContext())
            {
                var product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.UnitsInStock = message.UnitsInStock.HasValue ? message.UnitsInStock.Value : 0;
                context.SubmitChanges();
            }
        }
    }
}
