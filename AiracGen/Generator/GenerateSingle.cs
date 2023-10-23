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

            var yearAmount = currentYear <= identYear ? identYear - currentYear : currentYear - identYear;

            if(yearAmount == 0)
            {
                yearAmount = 1;
            }

            var airacs = AiracGenerator.GeneratePastAndFuture(15 * yearAmount, 15 * yearAmount);

            return airacs.FirstOrDefault(x => x.Ident == ident)
                ?? throw new Exception("Ident not found");
        }
    }
}
