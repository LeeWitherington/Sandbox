using System;
using Ncqrs.Eventing;

namespace MyShop.Events.VisitorEvents
{
    [Serializable]
    public class VisitRegistered : IEvent, IEquatable<VisitRegistered>
    {
        public Guid VisitorId { get; private set; }
        
        public DateTime TimeStamp { get; private set; }

        public String Url { get; private set; }

        public String IpAddress { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitRegistered"/> class.
        /// </summary>
        public VisitRegistered(Guid visitorId, DateTime timeStamp, string url, string ipAddress)
        {
            VisitorId = visitorId;
            TimeStamp = timeStamp;
            Url = url;
            IpAddress = ipAddress;
        }

        #region Equality

        public bool Equals(VisitRegistered other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.VisitorId.Equals(VisitorId) && other.TimeStamp.Equals(TimeStamp) && Equals(other.Url, Url) && Equals(other.IpAddress, IpAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (VisitRegistered)) return false;
            return Equals((VisitRegistered) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = VisitorId.GetHashCode();
                result = (result*397) ^ TimeStamp.GetHashCode();
                result = (result*397) ^ (Url != null ? Url.GetHashCode() : 0);
                result = (result*397) ^ (IpAddress != null ? IpAddress.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(VisitRegistered left, VisitRegistered right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VisitRegistered left, VisitRegistered right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
