using System;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.ProductCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.Product, MyShop.Domain", "UpdateUnitPrice")]
    public class UpdateUnitPriceOfProduct : ICommand, IEquatable<UpdateUnitPriceOfProduct>
    {
        public UpdateUnitPriceOfProduct(Guid productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        [AggregateRootId]
        public Guid ProductId { get; private set; }
        public Decimal UnitPrice { get; private set; }

        #region Equality

        public bool Equals(UpdateUnitPriceOfProduct other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && other.UnitPrice == UnitPrice;
        }   

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (UpdateUnitPriceOfProduct)) return false;
            return Equals((UpdateUnitPriceOfProduct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ProductId.GetHashCode()*397) ^ UnitPrice.GetHashCode();
            }
        }

        public static bool operator ==(UpdateUnitPriceOfProduct left, UpdateUnitPriceOfProduct right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateUnitPriceOfProduct left, UpdateUnitPriceOfProduct right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}