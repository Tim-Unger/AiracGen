namespace AiracGen.Generator
{
    internal class ByYear
    {
        internal static List<Airac> Generate(int year)
        {
            //If only a two "letter" year is provided, we assume that is means the current century, so we will add 2000 years
            if(year < 100)
            {
                year += 2000;
            }

            if(year.ToString().Length != 4)
            {
                throw new Exception("Year was not a valid year");
            }

            var maxAmountOfCyclesInYear = 0;

            var firstDayOfCurrentYear = new DateOnly(year, 1, 1);
            //We check how many Airac Cycles fit into the provided year
            while (firstDayOfCurrentYear.Year == firstDayOfCurrentYear.AddDays(28).Year)
            {
                maxAmountOfCyclesInYear++;
                firstDayOfCurrentYear = firstDayOfCurrentYear.AddDays(28);
            }

            var yearValue = year.ToString()[2..];

            var identList = new List<string>();

            for(var i = 1; i <= maxAmountOfCyclesInYear; i++)
            {
                var airacNumber = i.ToString();

                //We need to append a leading zero if the value is smaller than 10 to always get 4 chars
                if(i < 10)
                {
                    airacNumber = "0" + airacNumber;
                }

                //Generate the ident of the Airac
                var ident = yearValue + airacNumber;

                identList.Add(ident);
            }

            //We now have every possible Ident in the provided year, so we can create an Airac of every Ident
            return identList.Select(AiracGenerator.GenerateSingle).ToList();
        }
    }
}
