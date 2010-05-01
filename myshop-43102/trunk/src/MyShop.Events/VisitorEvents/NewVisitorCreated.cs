using System;
using Ncqrs.Eventing;
namespace MyShop.Events.VisitorEvents
{
    [Serializable]
    public class NewVisitorCreated : IEvent, IEquatable<NewVisitorCreated>
    {
        public Guid VisitorId
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public NewVisitorCreated(Guid visitorId)
        {
            VisitorId = visitorId;
        }

        #region Equality

        public bool Equals(NewVisitorCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.VisitorId.Equals(VisitorId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NewVisitorCreated)) return false;
            return Equals((NewVisitorCreated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = VisitorId.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(NewVisitorCreated left, NewVisitorCreated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NewVisitorCreated left, NewVisitorCreated right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
