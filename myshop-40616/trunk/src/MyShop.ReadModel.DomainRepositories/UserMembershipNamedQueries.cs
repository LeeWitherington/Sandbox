using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyShop.Domain.NamedQueries;

namespace MyShop.ReadModel.DomainRepositories
{
    public class UserMembershipNamedQueries : IUserMembershipNamedQueries
    {
        public bool IsUsernameInUse(string username)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                return context.Users.Count(u => u.Username == username) > 0;
            }
        }

        public bool IsEmailAddressInUse(string email)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                return context.Users.Count(u => u.Email == email) > 0;
            }
        }

        public bool DoesAUserExistWithCredentails(string username, string hashedPassword)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                return context.Users.Count(u => u.Username == username && u.Password == hashedPassword) > 0;
            }
        }

        public bool GetUserIdByCredentials(string username, string hashedPassword, out Guid userId)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                userId = (from u in context.Users
                          where u.Username == username && u.Password == hashedPassword
                          select u.Id).FirstOrDefault();

                if (userId != default(Guid))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
