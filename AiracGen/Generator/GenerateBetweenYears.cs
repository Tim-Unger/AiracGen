namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static List<Airac> GenerateBetweenYearsUnsorted(int startYear, int endYear) => (List<Airac>)BetweenYears(startYear, endYear, true);
        internal static List<List<Airac>> GenerateBetweenYearsSorted(int startYear, int endYear) => (List<List<Airac>>)BetweenYears(startYear, endYear, false);
       

        private static object BetweenYears(int startYear, int endYear, bool shouldBeSquashed)
        {
            var years = new List<int>();

            var currentYear = startYear;
            for (var i = startYear; i <= endYear; i++)
            {
                years.Add(currentYear);
                currentYear++;
            }

            if (shouldBeSquashed)
            {
                return years.Select(GenerateByYear).SelectMany(x => x).ToList();
            }

            return years.Select(GenerateByYear).ToList();
        }
    }
}
