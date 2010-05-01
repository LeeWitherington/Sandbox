using System;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.ShoppingCartCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("Myshop.Domain.ShoppingCart, MyShop.Domain", "RemoveProduct")]
    public class RemoveProductFromShoppingCart : ICommand, IEquatable<RemoveProductFromShoppingCart>
    {
        public RemoveProductFromShoppingCart()
        {
        }

        public RemoveProductFromShoppingCart(Guid shoppingCartId, Guid productId)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
        }

        [AggregateRootId]
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }

        #region Equality

        public bool Equals(RemoveProductFromShoppingCart other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.ProductId.Equals(ProductId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RemoveProductFromShoppingCart)) return false;
            return Equals((RemoveProductFromShoppingCart) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ShoppingCartId.GetHashCode()*397) ^ ProductId.GetHashCode();
            }
        }

        public static bool operator ==(RemoveProductFromShoppingCart left, RemoveProductFromShoppingCart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RemoveProductFromShoppingCart left, RemoveProductFromShoppingCart right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}