using System;
using Ncqrs.Eventing;

namespace MyShop.Events.ShoppingCartEvents
{
    [Serializable]
    public class ProductRemovedFromShoppingCart : IEvent, IEquatable<ProductRemovedFromShoppingCart>
    {
        public ProductRemovedFromShoppingCart(Guid shoppingCartId, Guid productId)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
        }

        public Guid ShoppingCartId { get; private set; }
        public Guid ProductId { get; private set; }

        #region Equality

        public bool Equals(ProductRemovedFromShoppingCart other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.ProductId.Equals(ProductId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ProductRemovedFromShoppingCart)) return false;
            return Equals((ProductRemovedFromShoppingCart) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ShoppingCartId.GetHashCode()*397) ^ ProductId.GetHashCode();
            }
        }

        public static bool operator ==(ProductRemovedFromShoppingCart left, ProductRemovedFromShoppingCart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductRemovedFromShoppingCart left, ProductRemovedFromShoppingCart right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}