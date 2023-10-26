namespace AiracGen.Generator
{
    internal static partial class AiracGenExtensions
    {
        internal static bool AreAllValuesCorrect(this List<Airac> airacs)
        {
            //Any ident is not 4 letters long
            if(airacs.Any(x => x.Ident.Length != 4))
            {
                throw new InvalidDataException("One ident is not four letters long");
            }

            //Any ident exists twice
            if(airacs.Count != airacs.DistinctBy(x => x.Ident).Count())
            {
                throw new InvalidDataException("One ident exists twice");
            }

            //A year has more than 14 Airacs (Mathematically impossible since 366/28 ≈ 13.1
            if (airacs.Any(x => x.NumberInYear > 14))
            {
                throw new InvalidDataException("One year has more airacs than possible");
            }

            return true;
        }
    }
}
