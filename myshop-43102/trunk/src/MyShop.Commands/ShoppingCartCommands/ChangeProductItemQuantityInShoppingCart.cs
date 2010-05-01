using System;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.ShoppingCartCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.ShoppingCart, MyShop.Domain", "ChangeProductQuanity")]
    public class ChangeProductItemQuantityInShoppingCart : ICommand, IEquatable<ChangeProductItemQuantityInShoppingCart>
    {
        public ChangeProductItemQuantityInShoppingCart()
        {
        }

        public ChangeProductItemQuantityInShoppingCart(Guid shoppingCartId, Guid productId, int newQuanity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            NewQuanity = newQuanity;
        }

        [AggregateRootId]
        public Guid ShoppingCartId { get; set; }

        public Guid ProductId { get; set; }

        public int NewQuanity { get; set; }

        #region Equality

        public bool Equals(ChangeProductItemQuantityInShoppingCart other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.ProductId.Equals(ProductId) && other.NewQuanity == NewQuanity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ChangeProductItemQuantityInShoppingCart)) return false;
            return Equals((ChangeProductItemQuantityInShoppingCart) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = ShoppingCartId.GetHashCode();
                result = (result*397) ^ ProductId.GetHashCode();
                result = (result*397) ^ NewQuanity;
                return result;
            }
        }

        public static bool operator ==(ChangeProductItemQuantityInShoppingCart left, ChangeProductItemQuantityInShoppingCart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeProductItemQuantityInShoppingCart left, ChangeProductItemQuantityInShoppingCart right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}