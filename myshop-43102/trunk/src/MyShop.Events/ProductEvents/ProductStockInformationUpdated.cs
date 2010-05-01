using System;
using Ncqrs.Eventing;

namespace MyShop.Events.ProductEvents
{
    [Serializable]
    public class ProductStockInformationUpdated : IEvent, IEquatable<ProductStockInformationUpdated>
    {
        public ProductStockInformationUpdated(Guid productId, int? unitsInStock)
        {
            ProductId = productId;
            UnitsInStock = unitsInStock;
        }

        public Guid ProductId { get; private set; }

        public int? UnitsInStock { get; private set; }

        #region Equality
        public bool Equals(ProductStockInformationUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && other.UnitsInStock.Equals(UnitsInStock);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ProductStockInformationUpdated)) return false;
            return Equals((ProductStockInformationUpdated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ProductId.GetHashCode()*397) ^ (UnitsInStock.HasValue ? UnitsInStock.Value : 0);
            }
        }

        public static bool operator ==(ProductStockInformationUpdated left, ProductStockInformationUpdated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductStockInformationUpdated left, ProductStockInformationUpdated right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}