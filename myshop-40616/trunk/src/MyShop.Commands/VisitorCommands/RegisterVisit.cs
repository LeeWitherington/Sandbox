using System;
using MyShop.Commands.AutoMapping;

namespace MyShop.Commands.VisitorCommands
{
    [Serializable]
    [MapsToAggregateRootMethod("MyShop.Domain.Visitor, MyShop.Domain")]
    public class RegisterVisit : ICommand, IEquatable<RegisterVisit>
    {
        /// <summary>
        /// Gets the session id of the visitor.
        /// </summary>
        /// <value>The visitor id.</value>
        [AggregateRootId]
        public Guid VisitorId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the URL that is visited.
        /// </summary>
        /// <value>The URL that is visited.</value>
        public String Url
        {
            get; set;
        }

        public String IpAddress
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public RegisterVisit(Guid visitorId, String url, String ipAddress)
        {
            VisitorId = visitorId;
            Url = url;
            IpAddress = ipAddress;
        }

        #region Equality
        public bool Equals(RegisterVisit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.VisitorId.Equals(VisitorId) && Equals(other.Url, Url) && Equals(other.IpAddress, IpAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RegisterVisit)) return false;
            return Equals((RegisterVisit) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = VisitorId.GetHashCode();
                result = (result*397) ^ (Url != null ? Url.GetHashCode() : 0);
                result = (result*397) ^ (IpAddress != null ? IpAddress.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(RegisterVisit left, RegisterVisit right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RegisterVisit left, RegisterVisit right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}