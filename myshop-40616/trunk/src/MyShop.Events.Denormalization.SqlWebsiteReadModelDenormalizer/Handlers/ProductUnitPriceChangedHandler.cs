using System;
using System.Linq;
using MyShop.Bus;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class ProductUnitPriceChangedHandler : IMessageHandler<ProductUnitPriceChanged>
    {
        public void Handle(ProductUnitPriceChanged message)
        {
            using (var context = new WebSiteReadModelDataContext())
            {
                var product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.UnitPrice = message.UnitPrice;
                context.SubmitChanges();
            }
        }
    }
}
