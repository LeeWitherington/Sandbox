using System;
using Ncqrs.Eventing;

namespace MyShop.Events.VisitorEvents
{
    public class VisitorIdentifiedAsOtherVisitor : IEvent, IEquatable<VisitorIdentifiedAsOtherVisitor>
    {
        public Guid VisitorId
        {
            get; private set;
        }

        public Guid OtherVisitorId
        {
            get; private set;
        }

        public VisitorIdentifiedAsOtherVisitor(Guid visitorId, Guid otherVisitorId)
        {
            VisitorId = visitorId;
            OtherVisitorId = otherVisitorId;
        }

        public bool Equals(VisitorIdentifiedAsOtherVisitor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.VisitorId.Equals(VisitorId) && other.OtherVisitorId.Equals(OtherVisitorId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (VisitorIdentifiedAsOtherVisitor)) return false;
            return Equals((VisitorIdentifiedAsOtherVisitor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (VisitorId.GetHashCode()*397) ^ OtherVisitorId.GetHashCode();
            }
        }

        public static bool operator ==(VisitorIdentifiedAsOtherVisitor left, VisitorIdentifiedAsOtherVisitor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VisitorIdentifiedAsOtherVisitor left, VisitorIdentifiedAsOtherVisitor right)
        {
            return !Equals(left, right);
        }
    }
}
