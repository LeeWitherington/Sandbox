﻿using System;
using System.Collections.Generic;
using MyShop.Domain.Security;
using MyShop.Events.VisitorEvents;
using Ncqrs.Domain;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Mapping;

namespace MyShop.Domain
{
    public class Visitor : AggregateRoot
    {
        private readonly IList<Visit> _visits = new List<Visit>();

        #region Initialization
        public Visitor(Guid visitorId)
        {
            var e = new NewVisitorCreated(visitorId);

            ApplyEvent(e);
        }

        public Visitor(IEnumerable<HistoricalEvent> history) : base(history)
        {
            // Base ctor handles everything.
        }
        #endregion

        public void RegisterVisit(String url, String ipAddress)
        {
            var stamp = DateTime.Now; // TODO: Replace for abstraction.
            var e = new VisitRegistered(Id, stamp, url, ipAddress);

            ApplyEvent(e);
        }

        public void TransferVisit(Visit v)
        {
            var e = new VisitTransfered(Id, v.TimeStamp, v.Url, v.IpAddress);

            ApplyEvent(e);
        }

        internal void IdentifyAsOtherVisitor(Visitor association)
        {
            foreach(var visit in _visits)
            {
                association.TransferVisit(visit);
            }

            var e = new VisitorIdentifiedAsOtherVisitor(Id, association.Id);
            ApplyEvent(e);
        }

        public Guid RegisterAsUser(String username, String hashedPassword, String email)
        {
            // TODO: Support this agian.
            //var namedQueries = MyShopWorld.Instance.IocContainer.GetInstance<IUserMembershipNamedQueries>();

            //if (namedQueries.IsUsernameInUse(username))
            //{
            //    throw new UsernameAllreadyInUseException(username);
            //}

            //if (namedQueries.IsEmailAddressInUse(email))
            //{
            //    throw new EmailAddressAllreadyInUseException(email);
            //}

            var newUser = new User(username, hashedPassword, email);
            newUser.AssociateWithVisitor(Id);
            return newUser.Id;
        }

        #region Event handlers
        [EventHandler]
        private void NewVisitorCreatedEventHandler(NewVisitorCreated e)
        {
            OverrideId(e.VisitorId);
        }

        [EventHandler]
        private void VisitorIdentifiedAsOtherVisitorEventHandler(VisitorIdentifiedAsOtherVisitor e)
        {
            _visits.Clear();
        }

        [EventHandler]
        private void VisitRegisteredEventHandler(VisitRegistered e)
        {
            var visit = new Visit(e.TimeStamp, e.Url, e.IpAddress);
            _visits.Add(visit);
        }

        [EventHandler]
        private void VisitTransferedEventHandler(VisitTransfered e)
        {
            var visit = new Visit(e.TimeStamp, e.Url, e.IpAddress);
            _visits.Add(visit);
        }
        #endregion
    }
}
