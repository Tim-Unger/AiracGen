namespace AiracGen.Generator
{
    internal class Future
    {
        internal static List<Airac> Generate(int amount)
        {
            var currentAirac = Current.Generate();

            var airacs = new List<Airac>()
            {
                currentAirac
            };

            var startDate = currentAirac.StartDate;
            var endDate = currentAirac.EndDate;
            var startIdent = currentAirac.Ident;
            var startNumber = currentAirac.NumberInYear;

            for (var i = 0; i < amount - 1; i++)
            {
                var airac = new Airac();

                startDate = startDate.AddDays(28);
                endDate = endDate.AddDays(28);

                airac.StartDate = startDate;
                airac.EndDate = endDate;

                if (startDate.Year != startDate.AddDays(-28).Year)
                {
                    //Increment the Airac Ident to the next year
                    var startIdentYear = int.Parse(startIdent.ToString()[..2]);

                    var nextYearIdent = $"{startIdentYear += 1}01";
                    startNumber = 1;

                    var nextIdent = nextYearIdent;

                    airac.Ident = nextIdent;
                    airac.NumberInYear = startNumber;

                    airacs.Add(airac);

                    startIdent = nextIdent;
                    continue;
                }
                startNumber++;

                var ident = int.Parse(startIdent.Substring(2, 2));

                var setIndex = ident > 8 ? 2 : 3;
                var takeIndex = setIndex == 3 ? 1 : 2;

                var identYear = startIdent[..2];
                var identNumber = int.Parse(startIdent.Substring(setIndex, takeIndex)) + 1;

                var identString = identNumber.ToString();

                //If the ident is smaller than 10, we have to add a leading zero, otherwise the ident will be too short
                if (identNumber < 10)
                {
                    identString = "0" + identNumber;
                }

                startIdent = $"{identYear}{identString}";

                airac.Ident = startIdent;
                airac.NumberInYear = startNumber;

                airacs.Add(airac);
            }

            if(airacs.Any(x => x.Ident.Length != 4))
            {
                throw new InvalidOperationException($"Something went wrong while generating Airacs, The ident");
            }

            return airacs;
        }
    }
}
