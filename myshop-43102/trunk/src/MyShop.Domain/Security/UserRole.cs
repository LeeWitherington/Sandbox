using System;
using Ncqrs.Domain;

namespace MyShop.Domain.Security
{
    public class UserRole
    {
        /// <summary>
        /// Represents an empty <see cref="UserRole"/>.
        /// </summary>
        public static readonly UserRole Empty = new UserRole(null);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name of the role.</value>
        public String Name
        {
            get; private set;
        }

        public UserRole(String roleName)
        {
            Name = roleName;
        }

        #region Equality
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(UserRole other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return String.Compare(other.Name, Name, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (UserRole)) return false;
            return Equals((UserRole) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (Name != null ? Name.ToUpperInvariant().GetHashCode() : 0);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(UserRole left, UserRole right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UserRole left, UserRole right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}