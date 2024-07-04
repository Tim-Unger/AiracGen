namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static Airac GenerateNext() => Next(null);
        internal static Airac GenerateNext(string ident) => Next(ident);
        
        private static Airac Next(string? ident)
        {
            if(ident is null)
            {
                //No ident assumes the current airac, so we will just create one airac in the future and return it
                return AiracGenerator.GenerateFuture(1)[0];
            }

            var currentAirac = AiracGenerator.GenerateSingle(ident);

            var numberInYear = currentAirac.StartDate.Year != currentAirac.StartDate.AddDays(28).Year ? 1 : currentAirac.NumberInYear += 1;

            return new Airac()
            {
                Ident = ident.IncrementIdent(currentAirac.StartDate),
                StartDate = currentAirac.StartDate.AddDays(28),
                EndDate = currentAirac.EndDate.AddDays(28),
                NumberInYear = numberInYear,
            };
        }
    }
}
