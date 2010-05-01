using System;
using MyShop.Bus;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class NewProductCreatedHandler : IMessageHandler<NewProductCreated>
    {
        public void Handle(NewProductCreated message)
        {
            using (var context = new WebSiteReadModelDataContext())
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
    }
}