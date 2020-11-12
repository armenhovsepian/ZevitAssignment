using System;

namespace ApplicationCore.Exceptions
{
    public class ContactException : Exception
    {
        public ContactException()
        {

        }

        public ContactException(string message) : base(message)
        {

        }

        public ContactException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
