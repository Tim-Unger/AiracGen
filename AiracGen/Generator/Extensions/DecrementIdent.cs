﻿namespace AiracGen.Generator
{
    internal static partial class AiracGenExtensions
    {
        internal static string DecrementIdent(this string startIdent, DateOnly startDate)
        {
            if (startDate.Year != startDate.AddDays(28).Year)
            {
                var maxAmountOfCyclesInYear = 0;
                var currentYear = startDate;

                var firstDayOfCurrentYear = new DateOnly(currentYear.Year, 1, 1);
                while (firstDayOfCurrentYear.Year == firstDayOfCurrentYear.AddDays(28).Year)
                {
                    maxAmountOfCyclesInYear++;
                    firstDayOfCurrentYear = firstDayOfCurrentYear.AddDays(28);
                }

                var startIdentYear = int.Parse(startIdent.ToString()[..2]);

                //Rollover from 2000 to 1999, since 2000 would be 0, 1999 would be -1, so we have to set the value to 100 to get 99 with the next subtraction
                if (startIdentYear == 0)
                {
                    startIdentYear = 100;
                }

                //Decrement the Airac Ident to the previous year
                var previousYearIdent = $"{startIdentYear -= 1}{maxAmountOfCyclesInYear}";

                //If the year is smaller than 10, we have to add a leading zero, otherwise the ident will be too short
                if (startIdentYear < 10)
                {
                    previousYearIdent = "0" + previousYearIdent;
                }

                return previousYearIdent;
            }

            var ident = int.Parse(startIdent.Substring(2, 2));

            var setIndex = ident > 8 ? 2 : 3;
            var takeIndex = setIndex == 3 ? 1 : 2;
            
            var identYear = startIdent.Substring(0,2);
            var identNumber = int.Parse(startIdent.Substring(setIndex, takeIndex)) - 1;

            var identString = identNumber.ToString();

            //If the ident is smaller than 10, we have to add a leading zero, otherwise the ident will be too short
            if (identNumber < 10)
            {
                identString = "0" + identNumber;
            }

            var concatIdent = $"{identYear}{identString}";

            return concatIdent;
        }
    }
}
