using System;
using MyShop.Bus;

namespace MyShop.Events.Denormalization.SqlWebsiteReadModelDenormalizer.Handlers
{
    public class NewUserCreatedHandler : IMessageHandler<NewUserCreated>
    {
        public void Handle(NewUserCreated message)
        {
            using (var context = new WebSiteReadModelDataContext())
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