using System;
using Ncqrs.Commands.Attributes;
using Ncqrs.Commands;

namespace MyShop.Commands.UserCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.Security.User, MyShop.Domain", "AssignRoleToUser")]
    public class AssignRoleToUser : ICommand, IEquatable<AssignRoleToUser>
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
        [AggregateRootId]
        public Guid UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignRoleToUser"/> class.
        /// </summary>
        public AssignRoleToUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignRoleToUser"/> class.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="userId">The user id.</param>
        public AssignRoleToUser(string roleName, Guid userId)
        {
            RoleName = roleName;
            UserId = userId;
        }

        #region Equality

        public bool Equals(AssignRoleToUser other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.RoleName, RoleName) && other.UserId.Equals(UserId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AssignRoleToUser)) return false;
            return Equals((AssignRoleToUser) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((RoleName != null ? RoleName.GetHashCode() : 0)*397) ^ UserId.GetHashCode();
            }
        }

        public static bool operator ==(AssignRoleToUser left, AssignRoleToUser right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssignRoleToUser left, AssignRoleToUser right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}