using System.IO;
using System.Linq;
using MyShop.Events.ProductEvents;
using MyShop.ReadModel.Denormalizers.Properties;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductImageChangedHandler : Denormalizer<ProductImageChanged>
    {
        public override void DenormalizeEvent(ProductImageChanged message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product product = context.Products.First(p => p.Id == message.ProductId);
                product.ImageFilename = message.Filename;
                context.SubmitChanges();

                if (message.ImageData != null && message.ImageData.Length > 0)
                {
                    string localFilePath = Path.Combine(Settings.Default.ProductImageDirectoryPath, message.Filename);
                    using (FileStream imageFile = File.Create(localFilePath))
                    {
                        imageFile.Write(message.ImageData, 0, message.ImageData.Length);
                    }
                }
            }
        }
    }
}