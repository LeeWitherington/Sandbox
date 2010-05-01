using System.IO;
using System.Linq;
using MyShop.Bus;
using MyShop.Events.ProductEvents;
using MyShop.ReadModel.Denormalizers.Properties;

namespace MyShop.ReadModel.Denormalizers
{
    public class ProductImageChangedHandler : IMessageHandler<ProductImageChanged>
    {
        #region IMessageHandler<ProductImageChanged> Members

        public void Handle(ProductImageChanged message)
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

        #endregion
    }
}