using System;

namespace MyShop.Domain
{
    public class Visit : IEquatable<Visit>
    {
        public DateTime TimeStamp { get; private set; }
        public string Url { get; private set; }
        public string IpAddress { get; private set; }

        public Visit(DateTime timeStamp, string url, string ipAddress)
        {
            TimeStamp = timeStamp;
            Url = url;
            IpAddress = ipAddress;
        }

        public bool Equals(Visit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.TimeStamp.Equals(TimeStamp) && Equals(other.Url, Url) && Equals(other.IpAddress, IpAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Visit)) return false;
            return Equals((Visit) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = TimeStamp.GetHashCode();
                result = (result*397) ^ (Url != null ? Url.GetHashCode() : 0);
                result = (result*397) ^ (IpAddress != null ? IpAddress.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(Visit left, Visit right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Visit left, Visit right)
        {
            return !Equals(left, right);
        }
    }
}
