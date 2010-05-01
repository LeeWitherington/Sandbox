using System;
using MyShop.Events.UserEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class RoleAssignedToUserHandler : Denormalizer<RoleAssignedToUser>
    {
        public override void DenormalizeEvent(RoleAssignedToUser message)
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
