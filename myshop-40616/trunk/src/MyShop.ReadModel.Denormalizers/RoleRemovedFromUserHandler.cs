using System;
using MyShop.Bus;
using MyShop.Events.UserEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class RoleRemovedFromUserHandler : IMessageHandler<RoleRemovedFromUser>
    {
        public void Handle(RoleRemovedFromUser message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var roleToRemove = new UserRole();
                context.UserRoles.DeleteOnSubmit(roleToRemove);
            }
        }
    }
}
