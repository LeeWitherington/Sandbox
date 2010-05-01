using System;
using Ncqrs.Eventing;

namespace MyShop.Events.ProductEvents
{
    /// <summary>
    /// Occurs when the general information of a product has been updated.
    /// This contains the updated information of the product.
    /// </summary>
    [Serializable]
    public class GeneralProductInformationUpdated : IEvent, IEquatable<GeneralProductInformationUpdated>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralProductInformationUpdated"/> class.
        /// </summary>
        /// <param name="id">The id of the product that has been updated.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public GeneralProductInformationUpdated(Guid id, String name, String description)
        {
            ProductId = id;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets the id of the product that has been updated.
        /// </summary>
        /// <value>The product id.</value>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description { get; private set; }

        #region Equality
        public bool Equals(GeneralProductInformationUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && Equals(other.Name, Name) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (GeneralProductInformationUpdated)) return false;
            return Equals((GeneralProductInformationUpdated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ProductId.GetHashCode();
                result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(GeneralProductInformationUpdated left, GeneralProductInformationUpdated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GeneralProductInformationUpdated left, GeneralProductInformationUpdated right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}