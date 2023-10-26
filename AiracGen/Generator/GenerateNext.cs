namespace AiracGen.Generator
{
    internal class Next
    {
        internal static Airac Generate() => GenerateNext(null);
        internal static Airac Generate(string ident) => GenerateNext(ident);
        
        private static Airac GenerateNext(string? ident)
        {
            if(ident is null)
            {
                //No ident assumes the current airac, so we will just create one airac in the future and return it
                return AiracGenerator.GenerateFuture(1)[1];
            }

            var currentAirac = AiracGenerator.GenerateSingle(ident);

            var numberInYear = currentAirac.StartDate.Year != currentAirac.StartDate.AddDays(28).Year ? 1 : currentAirac.NumberInYear++;

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
