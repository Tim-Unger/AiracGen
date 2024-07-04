namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        //TODO distinct duplicate years
        internal static List<Airac> GenerateForYearsUnsorted(params int[] years) =>
            years.Select(GenerateByYear)
            .SelectMany(x => x)
            .DistinctBy(x => x.Ident)
            .ToList();

        internal static List<List<Airac>> GenerateForYearsSorted(params int[] years) =>
            years.Select(GenerateByYear)
            .ToList();
    }
}
