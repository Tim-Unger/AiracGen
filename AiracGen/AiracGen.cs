using AiracGen.Generator;

namespace AiracGen
{
    public class AiracGenerator
    {
        public static List<Airac> GenerateFuture(int amount) => Future.Generate(amount);

        public static List<Airac> GeneratePast(int amount) => Past.Generate(amount);

        public static List<Airac> GeneratePastAndFuture(int pastAmount, int futureAmount) => PastAndFuture.Generate(pastAmount, futureAmount);

        public static Airac GenerateSingle(string ident) => Generator.Single.Generate(ident);

        public static List<Airac> GenerateMultiple(params string[] idents) => Multiple.Generate(idents);

        public static Airac GenerateCurrent() => Current.Generate();
    }
}