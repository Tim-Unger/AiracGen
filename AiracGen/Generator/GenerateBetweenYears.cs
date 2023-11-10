namespace AiracGen.Generator
{
    internal class BetweenYears
    {
        internal static List<Airac> GenerateUnsorted(int startYear, int endYear) => (List<Airac>)Generate(startYear, endYear, true);
        internal static List<List<Airac>> GenerateSorted(int startYear, int endYear) => (List<List<Airac>>)Generate(startYear, endYear, false);
       

        private static object Generate(int startYear, int endYear, bool shouldBeSquashed)
        {
            var airacs = new List<Airac>();

            var years = new List<int>();

            var currentYear = startYear;
            for (var i = startYear; i <= endYear; i++)
            {
                years.Add(currentYear);
                currentYear++;
            }

            if (shouldBeSquashed)
            {
                return years.Select(ByYear.Generate).ToList().SelectMany(x => x).ToList();
            }

            return years.Select(ByYear.Generate).ToList();
        }
    }
}
