using System;
using System.Linq;
using MyShop.Bus;
using System.IO;
using MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Properties;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class ProductImageChangedHandler : IMessageHandler<ProductImageChanged>
    {
        public void Handle(ProductImageChanged message)
        {
            using (var context = new WebSiteReadModelDataContext())
            {
                Product product = context.Products.First(p => p.Id == message.ProductId);
                product.ImageFilename = message.Filename;
                context.SubmitChanges();

                if (message.ImageData != null && message.ImageData.Length > 0)
                {
                    var localFilePath = Path.Combine(Settings.Default.ProductImageDirectoryPath, message.Filename);
                    using (var imageFile = File.Create(localFilePath))
                    {
                        imageFile.Write(message.ImageData, 0, message.ImageData.Length);
                    }
                }
            }
        }
    }
}
