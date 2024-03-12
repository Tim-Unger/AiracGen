namespace AiracGen.Generator
{
    internal class Previous
    {
        internal static Airac Generate() => GeneratePrevious(null);
        internal static Airac Generate(string ident) => GeneratePrevious(ident);

        private static Airac GeneratePrevious(string? ident)
        {
            if (ident is null)
            {
                //No ident assumes the current airac, so we will just create one airac in the past and return it
                return AiracGenerator.GeneratePast(1)[0];
            }

            var currentAirac = AiracGenerator.GenerateSingle(ident);

            var numberInYear = currentAirac.StartDate.Year != currentAirac.StartDate.AddDays(-28).Year ? 1 : currentAirac.NumberInYear -= 1;

            return new Airac()
            {
                Ident = ident.DecrementIdent(currentAirac.StartDate),
                StartDate = currentAirac.StartDate.AddDays(-28),
                EndDate = currentAirac.EndDate.AddDays(-28),
                NumberInYear = numberInYear,
            };
        }
    }
}
