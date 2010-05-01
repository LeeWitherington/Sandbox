using System;
using MyShop.Bus;
using MyShop.Events.VisitorEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class VisitorVisitedHandler : IMessageHandler<VisitRegistered>
    {
        public void Handle(VisitRegistered message)
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
