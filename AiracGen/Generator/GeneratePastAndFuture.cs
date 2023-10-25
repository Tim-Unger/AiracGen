namespace AiracGen.Generator
{
    internal class PastAndFuture
    {
        internal static List<Airac> Generate(int pastAmount, int futureAmount)
        {
            var airacs = new List<Airac>();

            airacs.AddRange(Past.Generate(pastAmount));
            airacs.AddRange(Future.Generate(futureAmount));

            return airacs
                .DistinctBy(x => x.Ident) //The current Airac gets added with the past and the future airac, so we have to delete one of them
                .OrderBy(x => x.Ident) //Sorts by Earliest Ident first, just in case anything got messed up by Distinct()
                .ToList();
        }
    }
}
