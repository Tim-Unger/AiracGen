namespace AiracGen.Generator
{
    internal static partial class AiracGenExtensions
    {
        internal static string IncrementIdent(this string startIdent, DateOnly startDate)
        {
            if (startDate.Year != startDate.AddDays(-28).Year)
            {
                //Increment the Airac Ident to the next year
                var startIdentYear = int.Parse(startIdent.ToString()[..2]);

                var nextYearIdent = $"{startIdentYear += 1}01";

                var nextIdent = nextYearIdent;

                startIdent = nextIdent;
                return nextIdent;
            }

            var ident = int.Parse(startIdent.Substring(2, 2));

            var setIndex = ident > 8 ? 2 : 3;
            var takeIndex = setIndex == 3 ? 1 : 2;

            var identYear = startIdent[..2];
            var identNumber = int.Parse(startIdent.Substring(setIndex, takeIndex)) + 1;

            var identString = identNumber.ToString();

            //If the ident is smaller than 10, we have to add a leading zero, otherwise the ident will be too short
            if (identNumber < 10)
            {
                identString = "0" + identNumber;
            }

           return $"{identYear}{identString}";
        }
    }
}
