using System;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.ShoppingCartCommands
{
    [Serializable]
    [MapsToAggregateRootConstructor("MyShop.Domain.ShoppingCart, MyShop.Domain")]
    public class CreateShoppingCartForVisitor : ICommand, IEquatable<CreateShoppingCartForVisitor>
    {
        public CreateShoppingCartForVisitor()
        {
        }

        public CreateShoppingCartForVisitor(Guid shoppingCartId, Guid visitorId)
        {
            ShoppingCartId = shoppingCartId;
            VisitorId = visitorId;
        }

        [AggregateRootId]
        public Guid ShoppingCartId { get; set; }
        public Guid VisitorId { get; set; }

        #region Equality

        public bool Equals(CreateShoppingCartForVisitor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ShoppingCartId.Equals(ShoppingCartId) && other.VisitorId.Equals(VisitorId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(CreateShoppingCartForVisitor)) return false;
            return Equals((CreateShoppingCartForVisitor)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ShoppingCartId.GetHashCode() * 397) ^ VisitorId.GetHashCode();
            }
        }

        public static bool operator ==(CreateShoppingCartForVisitor left, CreateShoppingCartForVisitor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateShoppingCartForVisitor left, CreateShoppingCartForVisitor right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
