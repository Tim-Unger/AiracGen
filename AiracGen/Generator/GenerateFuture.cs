using AiracGen.Generator.Extensions;
using System.Diagnostics;

namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static List<Airac> GenerateFuture(int amount)
        {
            if(amount < 0)
            {
                throw new InvalidDataException("Amount must be positive");
            }

            if(amount == 0)
            {
                throw new InvalidDataException("Amount can not be 0");
            }

            var currentAirac = GenerateCurrent();

            var airacs = new List<Airac>();

            var startDate = currentAirac.StartDate;
            var endDate = currentAirac.EndDate;
            var startIdent = currentAirac.Ident;
            var startNumber = currentAirac.NumberInYear;

            for (var i = 0; i < amount; i++)
            {
                var airac = new Airac();

                startDate = startDate.AddDays(28);
                endDate = endDate.AddDays(28);

                if(startDate.Year >= 2100)
                {
                    continue;
                }

                airac.StartDate = startDate;
                airac.EndDate = endDate;

                var nextStartNumber = startNumber += 1;
                startNumber = startDate.Year != startDate.AddDays(-28).Year ? 1 : nextStartNumber;

                startIdent = startIdent.IncrementIdent(startDate);
                airac.Ident = startIdent;
                airac.NumberInYear = startNumber;

                airacs.Add(airac);
            }

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
