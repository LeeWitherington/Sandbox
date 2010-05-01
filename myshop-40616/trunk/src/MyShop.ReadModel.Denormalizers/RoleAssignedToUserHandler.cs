using System;
using MyShop.Bus;
using MyShop.Events.UserEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class RoleAssignedToUserHandler : IMessageHandler<RoleAssignedToUser>
    {
        public void Handle(RoleAssignedToUser message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var assignedRole = new UserRole();
                assignedRole.UserId = message.UserId;
                assignedRole.RoleName = message.RoleName;

                context.UserRoles.InsertOnSubmit(assignedRole);
                context.SubmitChanges();
            }
        }
    }
}
