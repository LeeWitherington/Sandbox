using System.Linq;
using MyShop.Events.ProductEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductUnitPriceChangedHandler : Denormalizer<ProductUnitPriceChanged>
    {
        public override void DenormalizeEvent(ProductUnitPriceChanged message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.UnitPrice = message.UnitPrice;
                context.SubmitChanges();
            }
        }
    }
}