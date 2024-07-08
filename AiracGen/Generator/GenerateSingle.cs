namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static Airac GenerateByIdent(string ident)
        {
            if (ident.Length != 4)
            {
                throw new InvalidDataException("Please provide a four letter ident");
            }

            if(!int.TryParse(ident, out _))
            {
                throw new InvalidDataException("Ident is not a number");
            }

            var current = GenerateCurrent();
            if(ident == current.Ident)
            {
                return current;
            }

            var identYear = int.Parse(ident[..2]);
            var currentYear = int.Parse(
                DateOnly.FromDateTime(DateTime.UtcNow).Year.ToString()[2..]
            );

            //We have to subtract the smaller number, so if the ident year is larger we have to subtract the current year, if not we have to subtract the ident year
            var yearAmount = currentYear <= identYear ? identYear - currentYear : currentYear - identYear;

            yearAmount++;

            //Provided year is the current year
            if(yearAmount == 0)
            {
                yearAmount = 1;
            }

            //If the ident we are looking for is in the year 2099 we can't create any airacs for the year 2100 currently, so we will need to skip/ignore the future airacs for 2100
            var futureYearAmount = ident.StartsWith("99") ? 0 : yearAmount;

            //Generate 15* the amount of years in the ident given airacs. This insures that we cover every airac for every possible year
            var airacs = AiracGenerator.GeneratePastAndFuture(15 * yearAmount, 15 * futureYearAmount);

            var airac = airacs.FirstOrDefault(x => x.Ident == ident);
            return airac
                ?? throw new KeyNotFoundException($"Ident {ident} not found");
        }
    }
}
