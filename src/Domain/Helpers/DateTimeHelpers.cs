using System;

namespace Domain.Helpers
{
    public static class DateTimeHelpers
    {
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
                calculatedAge--;

            return calculatedAge;
        }
    }
}
