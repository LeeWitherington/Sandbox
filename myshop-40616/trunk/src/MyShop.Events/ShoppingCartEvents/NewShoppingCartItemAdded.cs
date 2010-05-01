using System;

namespace MyShop.Events.ShoppingCartEvents
{
    [Serializable]
    public class ProductAddedToShoppingCart : IEvent, IEquatable<ProductAddedToShoppingCart>
    {
        public ProductAddedToShoppingCart(Guid shoppingCartId, Guid productId, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ShoppingCartId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        #region Equality

        public bool Equals(ProductAddedToShoppingCart other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.ProductId.Equals(ProductId) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ProductAddedToShoppingCart)) return false;
            return Equals((ProductAddedToShoppingCart) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ShoppingCartId.GetHashCode();
                result = (result*397) ^ ProductId.GetHashCode();
                result = (result*397) ^ Quantity;
                return result;
            }
        }

        public static bool operator ==(ProductAddedToShoppingCart left, ProductAddedToShoppingCart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductAddedToShoppingCart left, ProductAddedToShoppingCart right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}