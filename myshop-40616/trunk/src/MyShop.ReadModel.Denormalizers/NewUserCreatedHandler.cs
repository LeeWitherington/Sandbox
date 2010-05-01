using MyShop.Bus;
using MyShop.Events.UserEvents;

namespace MyShop.ReadModel.Denormalizers
{
    public class NewUserCreatedHandler : IMessageHandler<NewUserCreated>
    {
        #region IMessageHandler<NewUserCreated> Members

        public void Handle(NewUserCreated message)
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

        #endregion
    }
}