using System;
using Ncqrs.Eventing;

namespace MyShop.Events.ProductEvents
{
    [Serializable]
    public class ProductImageChanged : IEvent, IEquatable<ProductImageChanged>
    {
        public ProductImageChanged(Guid productId, String filename, Byte[] imageData)
        {
            ProductId = productId;
            Filename = filename;
            ImageData = imageData;
        }

        public Guid ProductId { get; private set; }

        public String Filename { get; private set; }

        public Byte[] ImageData { get; private set; }

        #region Equality
        public bool Equals(ProductImageChanged other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && Equals(other.Filename, Filename) && Equals(other.ImageData, ImageData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ProductImageChanged)) return false;
            return Equals((ProductImageChanged) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ProductId.GetHashCode();
                result = (result*397) ^ (Filename != null ? Filename.GetHashCode() : 0);
                result = (result*397) ^ (ImageData != null ? ImageData.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(ProductImageChanged left, ProductImageChanged right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductImageChanged left, ProductImageChanged right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}