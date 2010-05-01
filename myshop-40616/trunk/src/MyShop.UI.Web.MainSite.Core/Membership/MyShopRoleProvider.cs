using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using MyShop.ReadModel;
using MyShop.Commands;
using MyShop.Commands.UserCommands;

namespace MyShop.UI.Web.MainSite.Core.Membership
{
    public class MyShopRoleProvider : RoleProvider
    {
        public MyShopRoleProvider()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ApplicationName = "MyShop";
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public override string ApplicationName { get; set; }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var query = from user in context.Users
                            join role in context.UserRoles on user.Id equals role.UserId
                            where user.Username == username
                            where role.RoleName == roleName
                            select role;

                return query.Count() > 0;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var query = from user in context.Users
                            join role in context.UserRoles on user.Id equals role.UserId
                            where user.Username == username
                            select role.RoleName;

                var buffer = new List<String>();
                buffer.AddRange(query);
                return buffer.ToArray();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var commandBuffer = new List<ICommand>();

            foreach(var username in usernames)
            {
                foreach(var rolename in roleNames)
                {
                    var userId = (Guid)System.Web.Security.Membership.GetUser(username).ProviderUserKey;

                    var assignRoleCommand = new AssignRoleToUser(rolename, userId);
                    commandBuffer.Add(assignRoleCommand);
                }
            }

            MyShopWebApplication.CommandBus.Publish(commandBuffer);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}