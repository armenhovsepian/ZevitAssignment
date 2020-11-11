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
            Value = phone;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
