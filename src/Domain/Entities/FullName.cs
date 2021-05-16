using Domain.Exceptions;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // Satisfy the serialization requirements
        private FullName()
        {
        }

        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ContactException("FirstName can not be null or empty");

            if (string.IsNullOrEmpty(lastName))
                throw new ContactException("LastName can not be null or empty");

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"{FirstName} {LastName}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            //return new object[] { FirstName, LastName };
            yield return FirstName;
            yield return LastName;
        }
    }
}
