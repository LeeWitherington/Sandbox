using System;
using MyShop.Commands.AutoMapping;

namespace MyShop.Commands.ProductCommands
{
    [Serializable]
    [MapsToAggregateRootConstructor("MyShop.Domain.Product, MyShop.Domain")]
    public class AddNewProduct : ICommand, IEquatable<AddNewProduct>
    {
        public AddNewProduct()
        {
        }

        public AddNewProduct(String name, String description, Decimal unitPrice, int unitsInStock)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public String Name { get; set; }

        public String Description { get; set; }

        public Decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        #region Equality

        public bool Equals(AddNewProduct other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && Equals(other.Description, Description) && other.UnitPrice == UnitPrice && other.UnitsInStock == UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AddNewProduct)) return false;
            return Equals((AddNewProduct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ UnitPrice.GetHashCode();
                result = (result*397) ^ UnitsInStock;
                return result;
            }
        }

        public static bool operator ==(AddNewProduct left, AddNewProduct right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddNewProduct left, AddNewProduct right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}