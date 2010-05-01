using System;

namespace MyShop.Domain.Security
{
    /// <summary>
    /// Occurs when a email address allready exists.
    /// </summary>
    public class EmailAddressAllreadyInUseException : Exception
    {
        /// <summary>
        /// Gets the email address that allready exists.
        /// </summary>
        /// <value>The email address that allready exists.</value>
        public String EmailAddress
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressAllreadyInUseException"/> class.
        /// </summary>
        /// <param name="emailAddress">The emailAddress that allready exists.</param>
        public EmailAddressAllreadyInUseException(string emailAddress)
            : this(String.Format("The email address '{0}' allready exists.", emailAddress), emailAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        /// <param name="emailAddress">The emailAddress that allready exists.</param>
        public EmailAddressAllreadyInUseException(string message, string emailAddress)
            : this(message, emailAddress, null)
        {
            EmailAddress = emailAddress;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public EmailAddressAllreadyInUseException(string message, string emailAddress, Exception innerException)
            : base(message, innerException)
        {
            EmailAddress = emailAddress;
        }
    }
}