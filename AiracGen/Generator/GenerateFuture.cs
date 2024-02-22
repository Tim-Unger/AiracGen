using System.Diagnostics;

namespace AiracGen.Generator
{
    internal class Future
    {
        internal static List<Airac> Generate(int amount)
        {
            var currentAirac = Current.Generate();

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

                airac.StartDate = startDate;
                airac.EndDate = endDate;

                startNumber = startDate.Year != startDate.AddDays(-28).Year ? 1 : startNumber += 1;

                startIdent = startIdent.IncrementIdent(startDate);
                airac.Ident = startIdent;
                airac.NumberInYear = startNumber;

                airacs.Add(airac);
            }

            //Checks that everything got generated correctly
            if (!airacs.AreAllValuesCorrect())
            {
                throw new UnreachableException(
                    "The program should have already thrown earlier, something went wrong"
                );
            }

            return airacs;
        }
    }
}
