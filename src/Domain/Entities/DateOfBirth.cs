using Domain.Exceptions;
using Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DateOfBirth : ValueObject
    {
        public DateTime Value { get; private set; }
        public DateOfBirth(DateTime value)
        {
            if (value == DateTime.MinValue)
                throw new ContactException("Invalid value.");

            if (value == DateTime.MaxValue)
                throw new ContactException("Invalid value.");

            if (DateTimeHelpers.CalculateAge(value) < 16)
                throw new ContactException("The age cannnot be less than 16 years.");

            Value = value.Date;

        }


        //public DateOfBirth(int year, int month, int day)
        //{
        //    var value = new DateTime(year, month, day);
        //    Value = value;

        //}


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
