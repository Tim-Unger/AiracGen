namespace AiracGen.Generator.Extensions
{
    public static partial class AiracGenExtensions 
    {
        internal static bool IsValidAirac(this string airac)
        {
            if (airac.Length != 4)
            {
                return false;
            }

            if(!int.TryParse(airac, out _))
            {
                return false;
            }

            var airacYear = int.Parse(airac[..2]);

            if(airacYear > 99 || airacYear < 0)
            {
                return false;
            }

            var airacNumber = int.Parse(airac[..^2]);

            //The maximum possible number of cycles in a year is 13 (266 / 28 ≈ 13.072)
            if (airacNumber > 13 || airacNumber < 0)
            {
                return false;
            }

            return true;
        }
    }
}
