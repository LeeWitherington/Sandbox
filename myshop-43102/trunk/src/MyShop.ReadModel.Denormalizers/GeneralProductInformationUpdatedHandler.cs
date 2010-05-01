using System.Linq;
using MyShop.Events.ProductEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class GeneralProductInformationUpdatedHandler : Denormalizer<GeneralProductInformationUpdated>
    {
        public override void DenormalizeEvent(GeneralProductInformationUpdated evnt)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = (from p in context.Products where p.Id == evnt.ProductId select p).First();
                product.Name = evnt.Name;
                product.Description = evnt.Description;
                context.SubmitChanges();
            }
        }
    }
}