using System;
using System.Linq;
using MyShop.Bus;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class GeneralProductInformationUpdatedHandler : IMessageHandler<GeneralProductInformationUpdated>
    {
        public void Handle(GeneralProductInformationUpdated message)
        {
            using (var context = new WebSiteReadModelDataContext())
            {
                var product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.Name = message.Name;
                product.Description = message.Description;
                context.SubmitChanges();
            }
        }
    }
}
