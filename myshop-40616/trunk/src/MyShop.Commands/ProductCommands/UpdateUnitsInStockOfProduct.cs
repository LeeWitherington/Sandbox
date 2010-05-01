using System;
using MyShop.Commands.AutoMapping;

namespace MyShop.Commands.ProductCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.Product, MyShop.Domain", "UpdateUnitsInStock")]
    public class UpdateUnitsInStockOfProduct : ICommand, IEquatable<UpdateUnitsInStockOfProduct>
    {
        public UpdateUnitsInStockOfProduct(Guid productId, int unitsInStock)
        {
            ProductId = productId;
            UnitsInStock = unitsInStock;
        }

        [AggregateRootId]
        public Guid ProductId { get; private set; }
        public int UnitsInStock { get; private set; }

        #region Equality

        public bool Equals(UpdateUnitsInStockOfProduct other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ProductId.Equals(ProductId) && other.UnitsInStock == UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (UpdateUnitsInStockOfProduct)) return false;
            return Equals((UpdateUnitsInStockOfProduct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ProductId.GetHashCode()*397) ^ UnitsInStock;
            }
        }

        public static bool operator ==(UpdateUnitsInStockOfProduct left, UpdateUnitsInStockOfProduct right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateUnitsInStockOfProduct left, UpdateUnitsInStockOfProduct right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}