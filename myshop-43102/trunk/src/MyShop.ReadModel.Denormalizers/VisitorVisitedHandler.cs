using System;
using MyShop.Events.VisitorEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class VisitorVisitedHandler : Denormalizer<VisitRegistered>
    {
        public override void DenormalizeEvent(VisitRegistered message)
        {
            using(var context = new MyShopReadModelDataContext())
            {
                var visit = new Visit();
                visit.Id = Guid.NewGuid();
                visit.VisitorId = message.VisitorId;
                visit.TimeStamp = message.TimeStamp;
                visit.IpAddress = message.IpAddress;
                visit.Url = message.Url;

                context.Visits.InsertOnSubmit(visit);
                context.SubmitChanges();
            }
        }
    }
}
