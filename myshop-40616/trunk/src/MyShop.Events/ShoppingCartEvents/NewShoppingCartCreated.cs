using System;

namespace MyShop.Events.ShoppingCartEvents
{
    /// <summary>
    /// Occurs when a new shopping cart has been created.
    /// </summary>
    [Serializable]
    public class NewShoppingCartCreated : IEvent, IEquatable<NewShoppingCartCreated>
    {
        /// <summary>
        /// Gets the visitor id.
        /// </summary>
        /// <value>The visitor id.</value>
        public Guid VisitorId
        {
            get; private set;
        }

        /// <summary>
        /// Gets the id of the shopping cart.
        /// </summary>
        /// <value>The id of the shopping cart.</value>
        public Guid ShoppingCartId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewShoppingCartCreated"/> class.
        /// </summary>
        /// <param name="visitorId">The id of the visitor that owns this cart.</param>
        /// <param name="shoppingCartId">The id of the shopping cart.</param>
        public NewShoppingCartCreated(Guid visitorId, Guid shoppingCartId)
        {
            VisitorId = visitorId;
            ShoppingCartId = shoppingCartId;
        }

        #region Equality

        public bool Equals(NewShoppingCartCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.VisitorId.Equals(VisitorId) && other.ShoppingCartId.Equals(ShoppingCartId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NewShoppingCartCreated)) return false;
            return Equals((NewShoppingCartCreated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (VisitorId.GetHashCode()*397) ^ ShoppingCartId.GetHashCode();
            }
        }

        public static bool operator ==(NewShoppingCartCreated left, NewShoppingCartCreated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NewShoppingCartCreated left, NewShoppingCartCreated right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}