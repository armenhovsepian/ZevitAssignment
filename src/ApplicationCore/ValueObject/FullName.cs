using System;
using System.Collections.Generic;

namespace ApplicationCore.ValueObject
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private FullName()
        {

        }
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public String fullName() => $"{FirstName} {LastName}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
