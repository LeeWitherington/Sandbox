using System;
using Ncqrs.Domain;

namespace MyShop.Domain
{
    /// <summary>
    /// Represents an image.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public String Filename { get; private set; }

        /// <summary>
        /// Gets the image data.
        /// </summary>
        /// <value>The data.</value>
        public Byte[] Data { get; private set; }  

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="data">The image data.</param>
        public Image(String filename, Byte[] data)
        {
            Filename = filename;
            Data = data;
        }

        #region Equality

        public static bool operator ==(Image left, Image right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Image left, Image right)
        {
            return !Equals(left, right);
        }

        public Boolean Equals(Image other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Filename, Filename) && DataEquals(other.Data, Data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Image)) return false;
            return Equals((Image) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Filename != null ? Filename.GetHashCode() : 0)*397) ^ (Data != null ? Data.GetHashCode() : 0);
            }
        }

        private static Boolean DataEquals(byte[] a, byte[] b)
        {
            var result = true;

            if(a.Length != b.Length)
            {
                result = false;
            }
            else
            {
                for(int i = 0; i < a.Length; i++)
                {
                    if(a[i] != b[i])
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}