using System;
using System.Collections.Generic;
using MyShop.Events.UserEvents;
using Ncqrs.Domain;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Mapping;

namespace MyShop.Domain.Security
{
    public class User : AggregateRoot
    {
        private EmailAddress _emailAddress;
        private String _hashedPassword;
        private String _username;
        private readonly IList<UserRole> _roles = new List<UserRole>(0);
        private Guid _visitorId;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="emailAddress">The email address.</param>
        internal User(String username, String hashedPassword, String emailAddress)
        {
            var e = new NewUserCreated(Guid.NewGuid(), username, hashedPassword, emailAddress);
            ApplyEvent(e);
        }

        public User(IEnumerable<HistoricalEvent> history)
            : base(history)
        {
        }

        public void AssignRoleToUser(String roleName)
        {
            if(String.IsNullOrEmpty(roleName)) throw new ArgumentNullException("roleName");

            var e = new RoleAssignedToUser(roleName, Id);
            ApplyEvent(e);
        }

        public void RemoveRoleFromUser(String roleName)
        {
            if (String.IsNullOrEmpty(roleName)) throw new ArgumentNullException("roleName");

            var e = new RoleRemovedFromUser(roleName, Id);
            ApplyEvent(e);
        }

        public void UserLoggedInEventHandler(UserLoggedIn e)
        {
            // Nothing todo.
        }

        [EventHandler]
        private void NewUserCreatedEventHandler(NewUserCreated e)
        {
            OverrideId(e.UserId);
            _username = e.Username;
            _hashedPassword = e.HashedPassword;
            _emailAddress = new EmailAddress(e.Email);
        }

        [EventHandler]
        private void RoleAssignedToUserEventHandler(RoleAssignedToUser e)
        {
            // TODO: Handle following situation: if(e.UserId != Id) ...

            var assignedRole = new UserRole(e.RoleName);
            if(!_roles.Contains(assignedRole))
            {
                _roles.Add(assignedRole);
            }
        }

        [EventHandler]
        private void RoleRemovedFromUserEventHandler(RoleRemovedFromUser e)
        {
            // TODO: Handle following situation: if(e.UserId != Id) ...

            var roleToRemove = new UserRole(e.RoleName);
            _roles.Remove(roleToRemove);
        }

        public void AssociateWithVisitor(Guid visitorId)
        {
            // This user is already associated with the specified visitor.
            if(_visitorId == visitorId) return;

            var newAssociation = UnitOfWork.Current.DomainRepository.GetById<Visitor>(visitorId);

            if(_visitorId != Guid.Empty)
            {
                var previousAssociation = UnitOfWork.Current.DomainRepository.GetById<Visitor>(_visitorId);
                previousAssociation.IdentifyAsOtherVisitor(newAssociation);
            }
        }
    }
}