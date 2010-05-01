using System;

namespace MyShop.Domain.Security
{
    /// <summary>
    /// Occurs when a username allready exists.
    /// </summary>
    public class UsernameAllreadyInUseException : Exception
    {
        /// <summary>
        /// Gets the username that allready exists.
        /// </summary>
        /// <value>The username that allready exists.</value>
        public String Username
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameAllreadyInUseException"/> class.
        /// </summary>
        /// <param name="username">The username that allready exists.</param>
        public UsernameAllreadyInUseException(string username) : this(String.Format("The username '{0}' allready exists.", username), username)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        /// <param name="username">The username that allready exists.</param>
        public UsernameAllreadyInUseException(string message, string username) : this(message, username, null)
        {
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public UsernameAllreadyInUseException(string message, string username, Exception innerException) : base(message, innerException)
        {
            Username = username;
        }
    }
}