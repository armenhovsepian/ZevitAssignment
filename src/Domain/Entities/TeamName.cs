using System.Collections.Generic;

namespace Domain.Entities
{
    public class TeamName : ValueObject
    {
        //private readonly string _value;
        public string Value { get; private set; }

        private TeamName()
        {

        }

        public TeamName(string name)
        {
            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
