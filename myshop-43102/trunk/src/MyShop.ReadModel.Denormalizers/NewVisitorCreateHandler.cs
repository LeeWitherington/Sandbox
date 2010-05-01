using System;
using MyShop.Events.VisitorEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewVisitorCreatedHandler : Denormalizer<NewVisitorCreated>
    {
        public override void DenormalizeEvent(NewVisitorCreated message)
        {
            using(var context = new MyShopReadModelDataContext())
            {
                var visitor = new Visitor();
                visitor.Id = message.VisitorId;

                context.Visitors.InsertOnSubmit(visitor);
                context.SubmitChanges();
            }
        }
    }
}
