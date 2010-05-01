using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using MyShop.Commands.UserCommands;
using MyShop.ReadModel;
using System.Web;

namespace MyShop.UI.Web.MainSite.Core.Membership
{
    public class MyShopMembershipProvider : MembershipProvider
    {
        public MyShopMembershipProvider()
        {
// ReSharper disable DoNotCallOverridableMethodsInConstructor
            ApplicationName = "MyShop";
// ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public override bool ValidateUser(String username, String password)
        {
            string hashPassword = EncodePassword(password);

            using (var context = new MyShopReadModelDataContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password == hashPassword);
                return user != null;
            }
        }

        public override MembershipUser CreateUser(String username, String password, String email,
                                                  String passwordQuestion, String passwordAnswer, bool isApproved,
                                                  object providerUserKey, out MembershipCreateStatus status)
        {
            // Make sure there is no user registered with this username.
            if (GetUser(username, false) != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }
                // Make sure there is no user registered with this email.
            else if (GetUserNameByEmail(email) != null)
            {
                status = MembershipCreateStatus.DuplicateEmail;
            }
            // Register user.
            else
            {
                // TODO: Wrap visitor logic.
                var visitorId = new Guid(HttpContext.Current.Request.Cookies["MyShopVisitorIdentifier"].Value);

                var hashedPassword = EncodePassword(password);
                var command = new RegisterNewUser(visitorId, username, email, hashedPassword);
                MyShopWebApplication.CommandService.Execute(command);

                status = MembershipCreateStatus.Success;
            }

            return GetUser(username, false);
        }

        public override MembershipUser GetUser(String username, bool userIsOnline)
        {
            MembershipUser result = null;

            using (var context = new MyShopReadModelDataContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    result = user.ToMembershipUser(Name);
                }
            }

            return result;
        }

        public override String GetUserNameByEmail(String email)
        {
            String result = null;

            using (var context = new MyShopReadModelDataContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    result = user.Username;
                }
            }

            return result;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var result = new MembershipUserCollection();

            using (var context = new MyShopReadModelDataContext())
            {
                totalRecords = context.Users.Count();

                foreach (User user in context.Users)
                {
                    result.Add(user.ToMembershipUser(Name));
                }
            }

            return result;
        }

        protected String EncodePassword(String originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = Encoding.ASCII.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' String
            return BitConverter.ToString(encodedBytes);
        }

        #region Default implementations

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override String ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 25; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 25; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 5; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override String PasswordStrengthRegularExpression
        {
            get { return String.Empty; }
        }

        public override bool ChangePasswordQuestionAndAnswer(String username, String password,
                                                             String newPasswordQuestion, String newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override String GetPassword(String username, String answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(String username, String oldPassword, String newPassword)
        {
            throw new NotImplementedException();
        }

        public override String ResetPassword(String username, String answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(String userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(String username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(String usernameToMatch, int pageIndex, int pageSize,
                                                                 out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(String emailToMatch, int pageIndex, int pageSize,
                                                                  out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            return 0;
        }

        #endregion
    }
}