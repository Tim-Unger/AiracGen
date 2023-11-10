using AiracGen.Generator;

namespace AiracGen
{
    public class AiracGenerator
    {
        /// <summary>
        /// Generate x amount of Airacs in the future
        /// </summary>
        /// <param name="amount">the amount of Airacs to generate</param>
        /// <returns></returns>
        public static List<Airac> GenerateFuture(int amount) => Future.Generate(amount);

        /// <summary>
        /// Generate x amount of Airacs in the past
        /// </summary>
        /// <param name="amount">the amount of Airacs to generate</param>
        /// <returns></returns>
        public static List<Airac> GeneratePast(int amount) => Past.Generate(amount);

        /// <summary>
        /// Generate x amount of Airacs in the past and y the amount of Airacs in the future
        /// </summary>
        /// <param name="pastAmount">the amount of past Airacs to generate</param>
        /// <param name="futureAmount">the amount of future Airacs to generate</param>
        /// <returns></returns>
        public static List<Airac> GeneratePastAndFuture(int pastAmount, int futureAmount) => PastAndFuture.Generate(pastAmount, futureAmount);

        /// <summary>
        /// Generate a single Airac identified by the ident provided
        /// </summary>
        /// <param name="ident">the ident of the Airac to generate</param>
        /// <returns></returns>
        public static Airac GenerateSingle(string ident) => Generator.Single.Generate(ident);

        /// <summary>
        /// Generate Airacs identified by the idents provided
        /// </summary>
        /// <param name="idents">the idents of the Airacs to generate</param>
        /// <returns></returns>
        public static List<Airac> GenerateMultiple(params string[] idents) => Multiple.Generate(idents);

        /// <summary>
        /// Get the current Airac
        /// </summary>
        /// <returns></returns>
        public static Airac GenerateCurrent() => Current.Generate();

        /// <summary>
        /// Get the next Airac
        /// </summary>
        /// <returns></returns>
        public static Airac GenerateNext() => Next.Generate();

        /// <summary>
        /// Get the next Airac based on the ident provided
        /// </summary>
        /// <param name="ident">the ident of the base/current Airac</param>
        /// <returns></returns>
        public static Airac GenerateNext(string ident) => Next.Generate(ident);

        /// <summary>
        /// Get the previous Airac
        /// </summary>
        /// <returns></returns>
        public static Airac GeneratePrevious() => Previous.Generate();

        /// <summary>
        /// Get the previous Airac based on the ident provided
        /// </summary>
        /// <param name="ident">the ident of the base/current Airac</param>
        /// <returns></returns>
        public static Airac GeneratePrevious(string ident) => Previous.Generate(ident);

        /// <summary>
        /// Get all Airacs in the provided year
        /// If you only provide two chars (e.g. 23) the program assums that you mean the current century (=> 2023)
        /// </summary>
        /// <param name="year">the year you want to get the Airacs of</param>
        /// <returns></returns>
        public static List<Airac> GenerateByYear(int year) => ByYear.Generate(year);

        /// <summary>
        /// Gets all Airacs between the given years (inclusive of the provided years)
        /// Squashed into a single List<Airac> with all Airacs
        /// </summary>
        /// <param name="startYear">The Start-Year</param>
        /// <param name="endYear">The End-Year</param>
        /// <returns></returns>
        public static List<Airac> GenerateBetweenYears(int startYear, int endYear) => BetweenYears.GenerateUnsorted(startYear, endYear);

        /// <summary>
        /// Gets all Airacs between the given years (inclusive of the provided years)
        /// The Airacs are sorted into sublists of the respective year
        /// </summary>
        /// <param name="startYear">The Start-Year</param>
        /// <param name="endYear">The End-Year</param>
        /// <returns></returns>
        public static List<List<Airac>> GenerateBetweenYearsSorted(int startYear, int endYear) => BetweenYears.GenerateSorted(startYear, endYear);

        /// <summary>
        /// Gets all Airacs of the given years
        /// Squashed into a single List<Airac> with all Airacs
        /// </summary>
        /// <param name="years">the respective years</param>
        /// <returns></returns>
        public static List<Airac> GenerateForYearsUnsorted(params int[] years) => ForYears.GenerateUnsorted(years);

        /// <summary>
        /// Gets all Airacs of the given years
        /// The Airacs are sorted into sublists of the respective year
        /// </summary>
        /// <param name="years">the respective years</param>
        /// <returns></returns>
        public static List<List<Airac>> GenerateForYearsSorted(params int[] years) => ForYears.GenerateSorted(years);
    }
}