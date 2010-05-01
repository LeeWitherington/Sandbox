using System.Linq;
using MyShop.Events.ProductEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductStockInformationUpdatedHandler : Denormalizer<ProductStockInformationUpdated>
    {
        public override void DenormalizeEvent(ProductStockInformationUpdated message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.UnitsInStock = message.UnitsInStock.HasValue ? message.UnitsInStock.Value : 0;
                context.SubmitChanges();
            }
        }
    }
}