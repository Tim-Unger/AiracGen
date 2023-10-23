namespace AiracGen.Generator
{
    internal class PastAndFuture
    {
        internal static List<Airac> Generate(int pastAmount, int futureAmount)
        {
            var airacs = new List<Airac>();

            airacs.AddRange(Past.Generate(pastAmount));
            airacs.AddRange(Future.Generate(futureAmount));

            return airacs.DistinctBy(x => x.Ident).OrderBy(x => x.Ident).ToList();
        }
    }
}
