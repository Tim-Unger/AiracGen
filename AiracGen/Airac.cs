namespace AiracGen
{
    public class Airac
    {
        public string Ident { get; set; } = DefaultAirac.StartIdent;

        public DateOnly StartDate { get; set; } = DefaultAirac.StartDate;

        public DateOnly EndDate { get; set; } = DefaultAirac.EndDate;

        public int NumberInYear { get; set; } = DefaultAirac.StartNumber;
    }
}
