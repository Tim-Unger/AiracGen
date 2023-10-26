using System.Text.Json;

namespace AiracGen.Generator
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public static string ToJson(this List<Airac> airacs) => JsonSerializer.Serialize(airacs, _options);

        public static string ToJson(this Airac airac) => JsonSerializer.Serialize(airac, _options);
    }

    public static class AiracExtensions
    {
        public static Airac NextAirac(this Airac airac) => AiracGenerator.GenerateNext(airac.Ident);

        public static Airac PreviousAirac(this Airac airac) => AiracGenerator.GeneratePrevious(airac.Ident);
    }

}
