using System.Diagnostics;

namespace AiracGen.Generator
{
    internal class Current
    {
        internal static Airac Generate()
        {
            //Default Start Airac
            var startDate = new DateOnly(2022, 01, 27);
            var endDate = startDate.AddDays(28);
            var startIdent = "2201";
            var startNumber = 1;

            var dateOnlyNow = DateOnly.FromDateTime(DateTime.UtcNow);

            //Users Date is somehow in the past
            if (dateOnlyNow < startDate)
            {
                throw new UnreachableException("You have somehow travelled to the past");
            }

            //Determine the current Airac
            while (startDate < dateOnlyNow && endDate < dateOnlyNow)
            {
                startDate = startDate.AddDays(28);
                endDate = endDate.AddDays(28);

                //Increment the Airac Ident to the next year
                if (startDate.Year != startDate.AddDays(-28).Year)
                {
                    var startIdentYear = int.Parse(startIdent.ToString()[..2]);

                    var nextYearIdent = $"{startIdentYear += 1}01";
                    startNumber = 1;

                    startIdent = nextYearIdent;

                    continue;
                }

                startNumber++;

                var ident = int.Parse(startIdent.Substring(2, 2));

                var setIndex = ident > 8 ? 2 : 3;
                var takeIndex = setIndex == 3 ? 1 : 2;

                var identYear = startIdent[..setIndex];
                var identNumber = int.Parse(startIdent.Substring(setIndex, takeIndex)) + 1;

                startIdent = $"{identYear}{identNumber}";
            }

            return new Airac()
            {
                StartDate = startDate,
                EndDate = endDate,
                Ident = startIdent,
                NumberInYear = startNumber
            };
        }
    }
}
