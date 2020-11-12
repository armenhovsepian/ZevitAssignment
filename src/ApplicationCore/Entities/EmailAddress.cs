using ApplicationCore.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ApplicationCore.Entities
{
    public class EmailAddress : ValueObject
    {
        public string Value { get; private set; }
        private EmailAddress()
        {

        }
        public EmailAddress(string email)
        {
            if (!IsValidEmail(email))
                throw new ContactException("Invalid e-mail address");

            Value = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^[a-z0-9][a-z0-9_\.-]{0,}[a-z0-9]@[a-z0-9][a-z0-9_\.-]{0,}[a-z0-9][\.][a-z0-9]{2,4}$");
        }
    }
}
