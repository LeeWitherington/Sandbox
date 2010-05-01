using System;
using MyShop.Bus;
using MyShop.Events.VisitorEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewVisitorCreatedHandler : IMessageHandler<NewVisitorCreated>
    {
        public void Handle(NewVisitorCreated message)
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
