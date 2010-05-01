using System;
using System.Text.RegularExpressions;
using Ncqrs.Domain;

namespace MyShop.Domain
{
    /// <summary>
    /// Represents an email address value.
    /// </summary>
    public class EmailAddress
    {
        #region Members
        /// <summary>
        /// Regular expression to use to validate an email address string value.
        /// </summary>
        /// <remarks>
        /// It verifies that: - Only letters, numbers and email acceptable symbols (+, _, -, .) 
        /// are allowed - No two different symbols may follow each other - Cannot begin with a 
        /// symbol - Ending domain must be at least 2 letters - Supports subdomains - TLD must 
        /// be between 2 and 6 letters (Ex: .ca, .museum) - Only (-) and (.) symbols are allowed 
        /// in domain, but not consecutively.
        /// </remarks>
        private const String ValidEmailRegex = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";

        /// <summary>
        /// The raw value that represents the e-mail address.
        /// </summary>
        private readonly String _value;

        /// <summary>
        /// Gets the raw string representation of the email address represented by this instance.
        /// </summary>
        public String Value
        {
            get
            {
                return _value;
            }
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="InvalidEmailAddressException">Thrown when <i>value</i> is not an valid email address.</exception>
        public EmailAddress(String value)
        {
            ValidateEmailAddressValue(value);

            _value = value;
        }

        /// <summary>
        /// Validates the email address value. If it is not valid an <see cref="InvalidEmailAddressException"/> is thrown.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="InvalidEmailAddressException">Thrown when <i>value</i> is not an valid email address.</exception>
        private static void ValidateEmailAddressValue(String value)
        {
            if(!Regex.IsMatch(value, ValidEmailRegex, RegexOptions.IgnoreCase))
            {
                throw new InvalidEmailAddressException(value, "value");
            }
        }
        #endregion

        #region Equality
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(EmailAddress other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._value, _value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (EmailAddress)) return false;
            return Equals((EmailAddress) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (_value != null ? _value.GetHashCode() : 0);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(EmailAddress left, EmailAddress right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(EmailAddress left, EmailAddress right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}