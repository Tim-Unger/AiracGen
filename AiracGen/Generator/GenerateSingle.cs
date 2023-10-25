namespace AiracGen.Generator
{
    internal class Single
    {
        internal static Airac Generate(string ident)
        {
            if (ident.Length != 4)
            {
                throw new ArgumentOutOfRangeException("Please provide a four letter ident");
            }

            var identYear = int.Parse(ident[..2]);
            var currentYear = int.Parse(
                DateOnly.FromDateTime(DateTime.UtcNow).Year.ToString()[2..]
            );

            //if (identYear >= currentYear && identYear)
            //{
            //    var futureYearAmount = identYear - currentYear;

            //    if (futureYearAmount == 0)
            //    {
            //        futureYearAmount = 1;
            //    }

            //    var futureAiracs = AiracGenerator.GenerateFuture(13 * futureYearAmount);

            //    return futureAiracs.FirstOrDefault(x => x.Ident == ident)
            //        ?? throw new Exception("Ident not found");
            //}

            //We have to subtract the smaller number, so if the ident year is larger we have to subtract the current year, if not we have to subtract the ident year
            var yearAmount = currentYear <= identYear ? identYear - currentYear : currentYear - identYear;

            if(yearAmount == 0)
            {
                yearAmount = 1;
            }

            //Generate 15* the amount of years in the ident given airacs. This insures that we cover every airac for every possible year
            var airacs = AiracGenerator.GeneratePastAndFuture(15 * yearAmount, 15 * yearAmount);

            return airacs.FirstOrDefault(x => x.Ident == ident)
                ?? throw new Exception("Ident not found");
        }
    }
}
