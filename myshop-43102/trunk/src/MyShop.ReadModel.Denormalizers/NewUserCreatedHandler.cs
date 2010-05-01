using MyShop.Events.UserEvents;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Denormalization;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewUserCreatedHandler : Denormalizer<NewUserCreated>
    {
        public override void DenormalizeEvent(NewUserCreated message)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                // Create new user.
                var user = new User
                               {
                                   Id = message.UserId,
                                   Username = message.Username,
                                   Password = message.HashedPassword,
                                   Email = message.Email
                               };

                // Submit creation.
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
            }
        }
    }
}