using System;
using MyShop.Commands.AutoMapping;

namespace MyShop.Commands.ProductCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.Product, MyShop.Domain", "UpdateGeneralProductInformation")]
    public class UpdateGeneralProductInformation : ICommand, IEquatable<UpdateGeneralProductInformation>
    {
        public UpdateGeneralProductInformation(Guid productId, String name, String description)
        {
            ProductId = productId;
            Name = name;
            Description = description;
        }

        [AggregateRootId]
        public Guid ProductId { get; private set; }

        public String Name { get; private set; }

        public String Description { get; private set; }

        #region Equality

        public bool Equals(UpdateGeneralProductInformation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && Equals(other.Name, Name) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (UpdateGeneralProductInformation)) return false;
            return Equals((UpdateGeneralProductInformation) obj);
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

        public static bool operator ==(UpdateGeneralProductInformation left, UpdateGeneralProductInformation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateGeneralProductInformation left, UpdateGeneralProductInformation right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}