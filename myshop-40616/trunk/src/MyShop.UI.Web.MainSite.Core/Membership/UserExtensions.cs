using System;
using System.Web.Security;
using MyShop.ReadModel;

namespace MyShop.UI.Web.MainSite.Core.Membership
{
    internal static class UserExtensions
    {
        public static MembershipUser ToMembershipUser(this User user, String providerName)
        {
            if (user == null)
                return null;

            return new MembershipUser(providerName, user.Username, user.Id, user.Email, null, null, true, false,
                                      DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                                      DateTime.MinValue);
        }
    }
}