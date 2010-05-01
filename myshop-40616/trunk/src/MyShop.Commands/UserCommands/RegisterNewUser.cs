using System;
using MyShop.Commands.AutoMapping;

namespace MyShop.Commands.UserCommands
{
    [MapsToAggregateRootMethod("MyShop.Domain.Visitor, MyShop.Domain", "RegisterAsUser")]
    public class RegisterNewUser : ICommand, IEquatable<RegisterNewUser>
    {
        public RegisterNewUser()
        {
        }

        public RegisterNewUser(Guid visitorId, String username, String email, String hashedPassword)
        {
            VisitorId = visitorId;
            Username = username;
            Email = email;
            HashedPassword = hashedPassword;
        }

        [AggregateRootId]
        public Guid VisitorId
        {
            get; set;
        }
        public String Username { get; set; }
        public String Email { get; set; }
        public String HashedPassword { get; set; }

        #region Equality

        public bool Equals(RegisterNewUser other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Username, Username) && Equals(other.Email, Email) && Equals(other.HashedPassword, HashedPassword);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RegisterNewUser)) return false;
            return Equals((RegisterNewUser) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Username != null ? Username.GetHashCode() : 0);
                result = (result*397) ^ (Email != null ? Email.GetHashCode() : 0);
                result = (result*397) ^ (HashedPassword != null ? HashedPassword.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(RegisterNewUser left, RegisterNewUser right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RegisterNewUser left, RegisterNewUser right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}