using System.Linq;
using MyShop.Bus;
using MyShop.Events.ProductEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class GeneralProductInformationUpdatedHandler : IMessageHandler<GeneralProductInformationUpdated>
    {
        public void Handle(GeneralProductInformationUpdated message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = (from p in context.Products where p.Id == message.ProductId select p).First();
                product.Name = message.Name;
                product.Description = message.Description;
                context.SubmitChanges();
            }
        }
    }
}