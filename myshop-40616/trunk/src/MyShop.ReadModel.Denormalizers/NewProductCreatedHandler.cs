using MyShop.Bus;
using MyShop.Events.ProductEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewProductCreatedHandler : IMessageHandler<NewProductCreated>
    {
        #region IMessageHandler<NewProductCreated> Members

        public void Handle(NewProductCreated message)
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