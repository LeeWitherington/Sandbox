using System;

namespace MyShop.Domain.NamedQueries
{
    public interface IUserMembershipNamedQueries
    {
        Boolean IsUsernameInUse(String username);
        Boolean IsEmailAddressInUse(String email);
        Boolean DoesAUserExistWithCredentails(string username, string hashedPassword);
        Boolean GetUserIdByCredentials(string username, string hashedPassword, out Guid userId);
    }
}