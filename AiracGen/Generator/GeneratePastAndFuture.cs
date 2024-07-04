namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static List<Airac> GeneratePastAndFuture(int pastAmount, int futureAmount)
        {
            var airacs = new List<Airac>();

            airacs.AddRange(GeneratePast(pastAmount));
            airacs.AddRange(GenerateFuture(futureAmount));

            return airacs
                .DistinctBy(x => x.Ident) //The current Airac gets added with the past and the future airac, so we have to delete one of them
                .OrderBy(x => x.Ident) //Sorts by Earliest Ident first, just in case anything got messed up by Distinct()
                .ToList();
        }
    }
}
