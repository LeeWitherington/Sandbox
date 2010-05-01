using System;
using MyShop.Commands.AutoMapping;

namespace MyShop.Commands.VisitorCommands
{
    [Serializable]
    [MapsToAggregateRootConstructor("MyShop.Domain.Visitor, MyShop.Domain")]
    public class AddNewVisitor : ICommand, IEquatable<AddNewVisitor>
    {
        /// <summary>
        /// Gets the session id of the visitor.
        /// </summary>
        /// <value>The visitor id.</value>
        public Guid VisitorId
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref=AddNewVisitor"/> class.
        /// </summary>
        public AddNewVisitor(Guid visitorId)
        {
            VisitorId = visitorId;
        }

        #region Equality

        public bool Equals(AddNewVisitor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.VisitorId.Equals(VisitorId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AddNewVisitor)) return false;
            return Equals((AddNewVisitor) obj);
        }

        public override int GetHashCode()
        {
            return VisitorId.GetHashCode();
        }

        public static bool operator ==(AddNewVisitor left, AddNewVisitor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddNewVisitor left, AddNewVisitor right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
