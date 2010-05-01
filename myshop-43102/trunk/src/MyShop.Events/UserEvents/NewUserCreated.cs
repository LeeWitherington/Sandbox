using System;
using Ncqrs.Eventing;

namespace MyShop.Events.UserEvents
{
    [Serializable]
    public class NewUserCreated : IEvent, IEquatable<NewUserCreated>
    {
        public NewUserCreated(Guid userId, String username, String hashedPassword, String email)
        {
            UserId = userId;
            Username = username;
            Email = email;
            HashedPassword = hashedPassword;
        }

        public Guid UserId { get; private set; }
        public String Username { get; private set; }
        public String HashedPassword { get; private set; }
        public String Email { get; private set; }

        #region Equality

        public bool Equals(NewUserCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.UserId.Equals(UserId) && Equals(other.Username, Username) && Equals(other.HashedPassword, HashedPassword) && Equals(other.Email, Email);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NewUserCreated)) return false;
            return Equals((NewUserCreated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = UserId.GetHashCode();
                result = (result*397) ^ (Username != null ? Username.GetHashCode() : 0);
                result = (result*397) ^ (HashedPassword != null ? HashedPassword.GetHashCode() : 0);
                result = (result*397) ^ (Email != null ? Email.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(NewUserCreated left, NewUserCreated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NewUserCreated left, NewUserCreated right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}