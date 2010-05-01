using MyShop.Events.ProductEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewProductCreatedHandler : Denormalizer<NewProductCreated>
    {
        #region IMessageHandler<NewProductCreated> Members

        public override void DenormalizeEvent(NewProductCreated message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                // Create new product.
                var product = new Product();
                product.Id = message.ProductId;
                product.Name = message.Name;
                product.Description = message.Description;
                product.UnitPrice = message.UnitPrice;
                product.UnitsInStock = message.UnitsInStock;

                // Put the product in the unit of work list.
                context.Products.InsertOnSubmit(product);

                // Submit changes.
                context.SubmitChanges();
            }
        }

        #endregion
    }
}