namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static List<Airac> GenerateBetweenYearsUnsorted(int startYear, int endYear, bool inclusive) => (List<Airac>)BetweenYears(startYear, endYear, true, inclusive);
        internal static List<List<Airac>> GenerateBetweenYearsSorted(int startYear, int endYear, bool inclusive) => (List<List<Airac>>)BetweenYears(startYear, endYear, false, inclusive);
       

        private static object BetweenYears(int startYear, int endYear, bool shouldBeSquashed, bool inclusive)
        {
            var years = new List<int>();

            if(startYear > endYear)
            {
                throw new InvalidDataException("Start Year was greater than the End Year");
            }

            if(startYear == endYear)
            {
                throw new InvalidDataException("Start and End year can not be the same");
            }

            if(startYear > 2098 || startYear < 2000)
            {
                throw new InvalidDataException("Start Year must be between 2000 and 2098");
            }

            if(endYear > 2099 || endYear < 2001)
            {
                throw new InvalidDataException("End Year must be between 2001 and 2099");
            }

            var currentYear = startYear;
            for (var i = startYear; i <= endYear; i++)
            {
                years.Add(currentYear);
                currentYear++;
            }

            //Remove the first and the last year since we want the years to be non inclusive
            if (!inclusive)
            {
                years.RemoveAt(0);
                years.RemoveAt(years[-1]);
            }

            if(years.Count == 0)
            {
                throw new InvalidDataException("No years found, if you set inclusive to false, you need to have at least one year between both years");
            }

            if (shouldBeSquashed)
            {
                return years.Select(GenerateByYear).SelectMany(x => x).ToList();
            }

            return years.Select(GenerateByYear).ToList();
        }
    }
}
