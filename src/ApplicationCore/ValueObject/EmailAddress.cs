using System.Collections.Generic;

namespace ApplicationCore.ValueObject
{
    public class EmailAddress : ValueObject
    {
        public string Value { get; private set; }
        private EmailAddress()
        {

        }
        public EmailAddress(string email)
        {
            Value = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
