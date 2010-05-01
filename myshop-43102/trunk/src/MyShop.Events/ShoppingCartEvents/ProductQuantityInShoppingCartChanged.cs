using System;
using Ncqrs.Eventing;

namespace MyShop.Events.ShoppingCartEvents
{
    [Serializable]
    public class ProductQuantityInShoppingCartChanged : IEvent, IEquatable<ProductQuantityInShoppingCartChanged>
    {
        public ProductQuantityInShoppingCartChanged(Guid shoppingCartId, Guid productId, int newQuantity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            NewQuantity = newQuantity;
        }

        public Guid ShoppingCartId { get; private set; }
        public Guid ProductId { get; private set; }
        public int NewQuantity { get; private set; }

        #region Equality

        public bool Equals(ProductQuantityInShoppingCartChanged other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.ProductId.Equals(ProductId) && other.NewQuantity == NewQuantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ProductQuantityInShoppingCartChanged)) return false;
            return Equals((ProductQuantityInShoppingCartChanged) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ShoppingCartId.GetHashCode();
                result = (result*397) ^ ProductId.GetHashCode();
                result = (result*397) ^ NewQuantity;
                return result;
            }
        }

        public static bool operator ==(ProductQuantityInShoppingCartChanged left, ProductQuantityInShoppingCartChanged right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductQuantityInShoppingCartChanged left, ProductQuantityInShoppingCartChanged right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}