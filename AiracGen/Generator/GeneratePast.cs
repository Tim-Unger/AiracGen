using AiracGen.Generator.Extensions;
using System.Diagnostics;

namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static List<Airac> GeneratePast(int amount)
        {
            if (amount < 0)
            {
                throw new InvalidDataException("Amount must be positive");
            }

            if (amount == 0)
            {
                throw new InvalidDataException("Amount can not be 0");
            }

            var currentAirac = GenerateCurrent();

            var airacs = new List<Airac>();

            var startDate = currentAirac.StartDate;
            var endDate = currentAirac.EndDate;
            var startIdent = currentAirac.Ident;
            var startNumber = currentAirac.NumberInYear;

            for (var i = 0; i <= amount - 1; i++)
            {
                var airac = new Airac();

                startDate = startDate.AddDays(-28);
                endDate = endDate.AddDays(-28);

                airac.StartDate = startDate;
                airac.EndDate = endDate;

                if (startDate.Year >= 2100)
                {
                    continue;
                }

                var maxAmountOfCyclesInYear = 0;
                var currentYear = startDate;

                var firstDayOfCurrentYear = new DateOnly(currentYear.Year, 1, 1);
                while (firstDayOfCurrentYear.Year == firstDayOfCurrentYear.AddDays(28).Year)
                {
                    maxAmountOfCyclesInYear++;
                    firstDayOfCurrentYear = firstDayOfCurrentYear.AddDays(28);
                }

                startNumber =
                    startDate.Year != startDate.AddDays(28).Year
                        ? maxAmountOfCyclesInYear
                        : startNumber -= 1;

                startIdent = startIdent.DecrementIdent(startDate);
                airac.Ident = startIdent;
                airac.NumberInYear = startNumber;

                airacs.Add(airac);
            }

            airacs = airacs.OrderBy(x => x.StartDate).ToList();

#if DEBUG
            //Checks that everything got generated correctly
            if (!airacs.AreAllValuesCorrect())
            {
                throw new UnreachableException(
                    "The program should have already thrown earlier, something went wrong"
                );
            }
#endif
            return airacs;
        }
    }
}
