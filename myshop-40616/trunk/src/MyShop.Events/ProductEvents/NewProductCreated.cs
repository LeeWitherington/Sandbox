using System;

namespace MyShop.Events.ProductEvents
{
    /// <summary>
    /// Occurs when the a new product has been created.
    /// This contains the updated information of the product.
    /// </summary>
    [Serializable]
    public class NewProductCreated : IEvent, IEquatable<NewProductCreated>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewProductCreated"/> class.
        /// </summary>
        /// <param name="id">The id of the product that has been created.</param>
        /// <param name="name">The name of the product that has been created.</param>
        /// <param name="description">The description of the product that has been created.</param>
        /// <param name="unitPrice">The unit price of the product that has been created.</param>
        /// <param name="unitsInStock">The units in stock of the product that has been created.</param>
        public NewProductCreated(Guid id, String name, String description, Decimal unitPrice, int unitsInStock)
        {
            ProductId = id;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        /// <summary>
        /// Gets the id of the product that has been created.
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

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public Decimal UnitPrice { get; private set; }

        /// <summary>
        /// Gets units in stock.
        /// </summary>
        /// <value>The units in stock.</value>
        public int UnitsInStock { get; private set; }

        #region Equality
        public bool Equals(NewProductCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && Equals(other.Name, Name) && Equals(other.Description, Description) && other.UnitPrice == UnitPrice && other.UnitsInStock == UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NewProductCreated)) return false;
            return Equals((NewProductCreated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ProductId.GetHashCode();
                result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ UnitPrice.GetHashCode();
                result = (result*397) ^ UnitsInStock;
                return result;
            }
        }

        public static bool operator ==(NewProductCreated left, NewProductCreated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NewProductCreated left, NewProductCreated right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}