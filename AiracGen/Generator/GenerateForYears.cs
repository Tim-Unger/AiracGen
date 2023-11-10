namespace AiracGen.Generator
{
    internal class ForYears
    {
        internal static List<Airac> GenerateUnsorted(params int[] years) => years.Select(ByYear.Generate).SelectMany(x => x).ToList();

        internal static List<List<Airac>> GenerateSorted(params int[] years) => years.Select(ByYear.Generate).ToList();
    }
}
