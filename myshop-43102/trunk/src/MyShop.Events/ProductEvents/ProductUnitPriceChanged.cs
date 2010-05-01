using System;
using Ncqrs.Eventing;

namespace MyShop.Events.ProductEvents
{
    [Serializable]
    public class ProductUnitPriceChanged : IEvent, IEquatable<ProductUnitPriceChanged>
    {
        public ProductUnitPriceChanged(Guid productId, Decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public Guid ProductId { get; private set; }

        public Decimal UnitPrice { get; private set; }

        #region Equality

        public bool Equals(ProductUnitPriceChanged other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && other.UnitPrice == UnitPrice;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ProductUnitPriceChanged)) return false;
            return Equals((ProductUnitPriceChanged) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ProductId.GetHashCode()*397) ^ UnitPrice.GetHashCode();
            }
        }

        public static bool operator ==(ProductUnitPriceChanged left, ProductUnitPriceChanged right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductUnitPriceChanged left, ProductUnitPriceChanged right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}