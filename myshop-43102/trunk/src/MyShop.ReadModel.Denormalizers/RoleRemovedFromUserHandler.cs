using System;
using MyShop.Events.UserEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class RoleRemovedFromUserHandler : Denormalizer<RoleRemovedFromUser>
    {
        public override void DenormalizeEvent(RoleRemovedFromUser message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var roleToRemove = new UserRole();
                context.UserRoles.DeleteOnSubmit(roleToRemove);
            }
        }
    }
}
