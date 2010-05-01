using System;

namespace MyShop.Events.UserEvents
{
    /// <summary>
    /// Occurs when a user logged in.
    /// </summary>
    public class UserLoggedIn : IEvent, IEquatable<UserLoggedIn>
    {
        /// <summary>
        /// Gets the user id of the user that logged in.
        /// </summary>
        /// <value>The user id.</value>
        public Guid UserId
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public UserLoggedIn(Guid userId)
        {
            UserId = userId;
        }

        #region Equality
        public bool Equals(UserLoggedIn other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.UserId, UserId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (UserLoggedIn)) return false;
            return Equals((UserLoggedIn) obj);
        }

        public override int GetHashCode()
        {
            return (UserId != null ? UserId.GetHashCode() : 0);
        }

        public static bool operator ==(UserLoggedIn left, UserLoggedIn right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserLoggedIn left, UserLoggedIn right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
