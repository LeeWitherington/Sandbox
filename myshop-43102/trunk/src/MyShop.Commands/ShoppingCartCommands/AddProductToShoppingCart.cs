using System;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.ShoppingCartCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.ShoppingCart, MyShop.Domain", "AddProduct")]
    public class AddProductToShoppingCart : ICommand, IEquatable<AddProductToShoppingCart>
    {
        public AddProductToShoppingCart()
        {
        }

        public AddProductToShoppingCart(Guid shoppingCartId, Guid productId, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }

        [AggregateRootId]
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        #region Equality

        public bool Equals(AddProductToShoppingCart other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.ProductId.Equals(ProductId) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AddProductToShoppingCart)) return false;
            return Equals((AddProductToShoppingCart) obj);
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

        public static bool operator ==(AddProductToShoppingCart left, AddProductToShoppingCart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddProductToShoppingCart left, AddProductToShoppingCart right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}