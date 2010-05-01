using System;
using System.IO;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.ProductCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.Product, MyShop.Domain", "ChangeProductImage")]
    public class ChangeProductImage : ICommand, IEquatable<ChangeProductImage>
    {
        public ChangeProductImage(Guid productId, String filename, Byte[] imageData)
        {
            ProductId = productId;
            Filename = filename;
            ImageData = imageData;
        }

        public ChangeProductImage(Guid productId, String filename, Stream imageData)
            : this(productId, filename, GetByteArrayFromStream(imageData))
        {
        }

        [AggregateRootId]
        public Guid ProductId { get; private set; }

        public String Filename { get; private set; }

        public Byte[] ImageData { get; private set; }

        private static Byte[] GetByteArrayFromStream(Stream stream)
        {
            if (stream.Position != 0)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            using (var buffer = new MemoryStream())
            {
                var chunk = new byte[1024];
                int bytesReaded = stream.Read(chunk, 0, chunk.Length);
                while (bytesReaded > 0)
                {
                    buffer.Write(chunk, 0, bytesReaded);
                    bytesReaded = stream.Read(chunk, 0, chunk.Length);
                }

                return buffer.ToArray();
            }
        }

        #region Equality

        public bool Equals(ChangeProductImage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && Equals(other.Filename, Filename) && Equals(other.ImageData, ImageData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ChangeProductImage)) return false;
            return Equals((ChangeProductImage) obj);
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

        public static bool operator ==(ChangeProductImage left, ChangeProductImage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeProductImage left, ChangeProductImage right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}