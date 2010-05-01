using System;

namespace MyShop.Domain
{
    public class InvalidEmailAddressException : ArgumentException
    {
        public String Value
        {
            get;
            private set;
        }

        public InvalidEmailAddressException(String value, String paramName)
            : base(String.Format("The value '{0}' is not an valid email address.", value), paramName)
        {
            Value = value;
        }
    }
}
