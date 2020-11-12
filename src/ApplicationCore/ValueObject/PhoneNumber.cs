using ApplicationCore.Exceptions;
using System.Collections.Generic;

namespace ApplicationCore.ValueObject
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; private set; }

        private PhoneNumber()
        {

        }
        public PhoneNumber(string phone)
        {
            if(string.IsNullOrEmpty(phone))
                throw new ContactException("Phone can not be null or empty");

            Value = phone;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
