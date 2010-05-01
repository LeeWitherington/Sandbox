using System;

namespace MyShop.Events.UserEvents
{
    [Serializable]
    public class RoleRemovedFromUser : IEvent, IEquatable<RoleRemovedFromUser>
    {
        /// <summary>
        /// Gets or the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        public String RoleName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        /// <value>The user id.</value>
        public Guid UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRemovedFromUser"/> class.
        /// </summary>
        public RoleRemovedFromUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRemovedFromUser"/> class.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="userId">The user id.</param>
        public RoleRemovedFromUser(string roleName, Guid userId)
        {
            RoleName = roleName;
            UserId = userId;
        }

        #region Equality

        public bool Equals(RoleRemovedFromUser other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.RoleName, RoleName) && other.UserId.Equals(UserId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RoleRemovedFromUser)) return false;
            return Equals((RoleRemovedFromUser) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((RoleName != null ? RoleName.GetHashCode() : 0)*397) ^ UserId.GetHashCode();
            }
        }

        public static bool operator ==(RoleRemovedFromUser left, RoleRemovedFromUser right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoleRemovedFromUser left, RoleRemovedFromUser right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
